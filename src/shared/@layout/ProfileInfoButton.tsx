import { DownOutlined } from '@ant-design/icons';
import { Avatar, Button, Col, Dropdown, Menu, Row } from 'antd';
import { logout } from 'auth/+state/actionCreators';
import { authStateSelector } from 'auth/+state/authSelectors';
import { UserProfileInfo } from 'auth/models/userProfileInfo';
import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';

export type ProfileInfoButtonProps = {
  userInfo: UserProfileInfo;
};

export type ProfileInfoMenuProps = {
  userInfo: UserProfileInfo;
  onLogout: () => void;
};

export const ProfileInfoMenu = ({ userInfo, onLogout }: ProfileInfoMenuProps) => {
  return (
    <Menu>
      <Menu.Item>
        <span>Profile</span>
        <Link to="/profile" />
      </Menu.Item>
      <Menu.Item>
        <Button
          type="link"
          href="#"
          onClick={event => {
            event.preventDefault();
            onLogout();
          }}
        >
          Logout
        </Button>
      </Menu.Item>
    </Menu>
  );
};

export const ProfileInfoButton = ({ userInfo }: ProfileInfoButtonProps) => {
  return (
    <Dropdown overlay={<ProfileMenuConnected />} trigger={['click']} placement="bottomRight" className="profile-button">
      <Row justify="end" gutter={[8, 0]}>
        <Col>
          <Avatar src={userInfo.avatarUrl}></Avatar>
        </Col>
        <Col>
          <div className="user-full-name">
            {userInfo.firstName} {userInfo.lastName}
          </div>
        </Col>
        <Col>
          <DownOutlined />
        </Col>
      </Row>
    </Dropdown>
  );
};

const mapDispatchToProps = (dispatch: any) => ({
  onLogout: () => dispatch(logout()),
});

export const ProfileMenuConnected = connect(authStateSelector, mapDispatchToProps)(ProfileInfoMenu);

export default connect(authStateSelector)(ProfileInfoButton);
