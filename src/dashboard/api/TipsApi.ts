import { Http } from 'shared/api/http';
import { Tip } from './../model/tip';

export class TipsApi {
  private readonly _http: Http;

  constructor() {
    this._http = new Http();
  }

  async getMyTip() {
    const tip = await this._http.get<Tip>('tips/me');
    return tip;
  }

  async getAllTips() {
    const tips = await this._http.get<Tip[]>('tips');
    return tips;
  }
}
