import { ReloadOutlined } from '@ant-design/icons';
import { Avatar, Button, Col, Row } from 'antd';
import React, { useEffect, useState } from 'react';

export type AvatarFieldProps = {
  gender: string;
  value?: string;
  onChange?: (src: string) => void;
};
export const AvatarField = ({ gender, value, onChange }: AvatarFieldProps) => {
  const [seed, setSeed] = useState(Math.floor(Math.random() * 100 + 1));

  const generateImage = () => {
    const random = Math.floor(Math.random() * 100 + 1);
    setSeed(random);
  };

  useEffect(() => {}, [seed, gender]);

  return (
    <div className="avatar-field">
      <Row justify="start">
        <Col span={4}>
          <Avatar size="large" src={`https://avatars.dicebear.com/v2/${gender}/${seed}.svg`}></Avatar>
        </Col>
        <Col span={4}>
          <Button shape="circle" onClick={generateImage}>
            <ReloadOutlined />
          </Button>
        </Col>
      </Row>
    </div>
  );
};
