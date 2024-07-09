import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { TempUnit } from 'utils/unitConversion';
import { IAppState } from 'types/state.interface';

const initialState: IAppState = {
  tempUnit: TempUnit.CELCIUS,
  isLoading: false,
  isInitial: true,
};

const appSlice = createSlice({
  name: 'app',
  initialState,
  reducers: {
    changeTempUnit: (state: IAppState) => {
      state.tempUnit =
        state.tempUnit === TempUnit.CELCIUS
          ? TempUnit.FAHRENHEIT
          : TempUnit.CELCIUS;
    },
    setIsLoading: (state: IAppState, action: PayloadAction<boolean>) => {
      state.isLoading = action.payload;
    },
    setIsInitial: (state: IAppState, action: PayloadAction<boolean>) => {
      state.isInitial = action.payload;
    },
  },
});

export const { changeTempUnit, setIsLoading, setIsInitial } = appSlice.actions;
export default appSlice.reducer;
