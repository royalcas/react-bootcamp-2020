import { isEmpty } from 'lodash';

/**
 * This class centralized all the I/O operations to storage
 * Allowing the application to change the storage mechanism according to security requirements
 */
export class AppStorageManager {
  get<TDataType>(key: string): TDataType {
    const value = localStorage.getItem(key) as string;
    if (isEmpty(value)) return null as any;

    return JSON.parse(value) as TDataType;
  }

  getRaw(key: string): string | null {
    return localStorage.getItem(key);
  }

  set<TDataType>(key: string, value: TDataType): void {
    this.setRaw(key, JSON.stringify(value));
  }

  setRaw(key: string, value: string): void {
    localStorage.setItem(key, value);
  }

  hasValue(key: string): boolean {
    return !isEmpty(this.getRaw(key));
  }

  clearAll(): void {
    localStorage.clear();
  }

  clear(key: string): void {
    localStorage.removeItem(key);
  }
}
