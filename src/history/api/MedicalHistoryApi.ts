import axios from 'axios';
import { MedicalHistoryModel } from './../models/MedicalHistoryModel';

export class MedicalHistoryApi {
  async getMedicalHistoryByUser(userId: string) {
    const response = await axios.get('/data/history.json');
    return response.data as MedicalHistoryModel[];
  }
}
