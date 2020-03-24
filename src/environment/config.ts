import DevConfig from './config.dev';
import ProdConfig from './config.prod';

export type AppConfig = {
  apiBaseUrl: string;
};

export const config = process.env.REACT_APP_STAGE === 'prod' ? ProdConfig : DevConfig;
