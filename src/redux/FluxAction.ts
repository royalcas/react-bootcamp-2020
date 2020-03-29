import { Action } from 'redux';

export interface FluxAction<TActionType, TPayload> extends Action<TActionType> {
  payload: TPayload;
}
