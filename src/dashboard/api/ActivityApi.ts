import { Http } from 'shared/api/http';
import { Activity } from './../model/activity';

export class ActivityApi {
  private readonly _http: Http;

  constructor() {
    this._http = new Http();
  }

  async getSubscribedActivities() {
    const activities = await this._http.get<Activity[]>('activityTopics/me');
    return activities;
  }

  async getSuggestedActivities() {
    const activities = await this._http.get<Activity[]>('activityTopics/suggestions');
    return activities;
  }
}
