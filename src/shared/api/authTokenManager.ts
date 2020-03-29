import { AppStorageManager } from './storageManager';

const tokenStorageKey = 'authentication-token';
export class AuthTokenManager {
  private readonly _storage: AppStorageManager;

  constructor() {
    this._storage = new AppStorageManager();
  }

  hasToken(): boolean {
    return this._storage.hasValue(tokenStorageKey);
  }

  setToken(token: string): void {
    this._storage.setRaw(tokenStorageKey, token);
  }

  deleteToken(): void {
    this._storage.clear(tokenStorageKey);
  }

  getToken(): string {
    return this._storage.getRaw(tokenStorageKey) as string;
  }
}
