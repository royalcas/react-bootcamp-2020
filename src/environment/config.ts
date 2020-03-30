import DevConfig from './config.dev';
import ProdConfig from './config.prod';

export type AppConfig = {
  apiBaseUrl: string;
};

export const config = process.env.NODE_ENV === 'production' ? ProdConfig : DevConfig;

export default config;
