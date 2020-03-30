import { ReloadOutlined } from '@ant-design/icons';
import { Avatar, Button, Col, Row } from 'antd';
import { UserGender } from 'auth/models/userProfileInfo';
import { isEmpty } from 'lodash';
import React, { useEffect } from 'react';

export type AvatarFieldProps = {
  gender: UserGender;
  value?: string;
  onChange?: (src: string) => void;
};
export const AvatarField = ({ gender, value, onChange }: AvatarFieldProps) => {
  const genderString = gender === UserGender.Male ? 'male' : gender === UserGender.Female ? 'female' : 'bottts';

  const generateImage = () => {
    const random = Math.floor(Math.random() * 1000 + 1);
    if (onChange) onChange(`https://avatars.dicebear.com/v2/${genderString}/${random}.svg`);
  };

  if (isEmpty(value)) {
    generateImage();
  }

  useEffect(() => {
    generateImage();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [gender]);

  return (
    <div className="avatar-field">
      <Row justify="center">
        <Col>
          <Avatar size="large" src={value}></Avatar>
        </Col>
        <Col>
          <Button shape="circle" onClick={generateImage}>
            <ReloadOutlined />
          </Button>
        </Col>
      </Row>
    </div>
  );
};
