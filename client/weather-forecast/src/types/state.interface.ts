import { TempUnit } from 'utils/unitConversion';

export interface IAppState {
  tempUnit: TempUnit;
  isLoading: boolean;
  isInitial: boolean;
}
