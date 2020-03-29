import axios, { AxiosRequestConfig } from 'axios';
import config from 'environment/config';
import { AuthTokenManager } from './authTokenManager';

export class Http {
  private readonly _authTokenManager: AuthTokenManager;

  constructor() {
    this._authTokenManager = new AuthTokenManager();
  }

  async get<TResponseType = any>(resource: string, params: any = {}): Promise<TResponseType> {
    const endpoint = this.getEndpointUrlFromResource(resource);
    const options = this.getRequestConfig(params);
    const axiosResponse = await axios.get<TResponseType>(endpoint, options);
    return axiosResponse.data;
  }

  async post<TResponseType = any>(resource: string, data: any, params: any = {}): Promise<TResponseType> {
    const endpoint = this.getEndpointUrlFromResource(resource);
    const options = this.getRequestConfig(params);
    const axiosResponse = await axios.post<TResponseType>(endpoint, data, options);
    return axiosResponse.data;
  }

  async put<TResponseType = any>(resource: string, data: any, params: any = {}): Promise<TResponseType> {
    const endpoint = this.getEndpointUrlFromResource(resource);
    const options = this.getRequestConfig(params);
    const axiosResponse = await axios.put<TResponseType>(endpoint, data, options);
    return axiosResponse.data;
  }

  private getRequestConfig(params?: any): AxiosRequestConfig {
    const headers: any = {};

    if (this._authTokenManager.hasToken()) {
      headers['Authorization'] = `Bearer ${this._authTokenManager.getToken()}`;
    }

    return {
      headers,
      params,
    };
  }

  private getEndpointUrlFromResource = (resourceName: string) => `${config.apiBaseUrl}${resourceName}`;
}
