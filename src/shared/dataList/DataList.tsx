import { Button, Empty } from 'antd';
import { isEmpty } from 'lodash';
import React, { ReactNode, ReactNodeArray } from 'react';
import { SkeletonLoading } from 'shared/loading/Loading';

export type DataListProps = {
  data: any[];
  isLoading?: boolean;
  emptyMessage?: string;
  callToAction?: () => void;
  callToActionText?: string;
  children: (item: any) => ReactNode | ReactNodeArray;
};

export const NoDataContent = (props: DataListProps) => {
  const callToActionElement = !isEmpty(props.callToActionText) ? (
    <Button type="primary" onClick={props.callToAction}>
      {props.callToActionText}
    </Button>
  ) : (
    <></>
  );

  return <Empty description={props.emptyMessage}>{callToActionElement}</Empty>;
};

export const DataContent = (props: DataListProps) => {
  return isEmpty(props.data) ? <NoDataContent {...props} /> : <>{props.data.map(item => props.children(item))}</>;
};

export const DataList = (props: DataListProps) => {
  return props.isLoading ? <SkeletonLoading /> : <DataContent {...props} />;
};
