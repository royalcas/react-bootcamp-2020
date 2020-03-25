import { Action } from 'redux';

export interface FluxAction<TPayload> extends Action {
  payload: TPayload;
}
