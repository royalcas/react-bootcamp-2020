import { Http } from 'shared/api/http';
import { MedicalRecordItem } from './../models/MedicalRecordItem';

export class MedicalRecordApi {
  private readonly _http: Http;

  constructor() {
    this._http = new Http();
  }

  async getMedicalRecord(): Promise<MedicalRecordItem[]> {
    return await this._http.get<MedicalRecordItem[]>('me/medicalRecord');
  }

  async addMedicalRecord(item: MedicalRecordItem): Promise<MedicalRecordItem[]> {
    return await this._http.post<MedicalRecordItem[]>('medicalRecord', item);
  }
}
