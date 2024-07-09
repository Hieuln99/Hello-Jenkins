import { ToggleSwitch } from 'components/ToggleSwitch';
import './index.css';
import { useDispatch, useSelector } from 'react-redux';
import { useEffect } from 'react';
import { ReactComponent as HighIcon } from 'assets/high-icon.svg';
import { ReactComponent as HumidityIcon } from 'assets/humidity-icon.svg';
import { ReactComponent as LowIcon } from 'assets/low-icon.svg';
import { ReactComponent as PressureIcon } from 'assets/pressure-icon.svg';
import { ReactComponent as WindIcon } from 'assets/wind-icon.svg';
import WeatherIcon from './WeatherIcon';
import Temperature from './Temperature';
import { AppStore } from 'store';
import { TempUnit, kmToMile } from 'utils/unitConversion';
import { changeTempUnit } from 'store/reducers/appReducer';

const CurrentWeather = () => {
  const { weather, degreeType, isInitial, isError } = useSelector(
    (store: AppStore) => ({
      weather: store.weather.weatherData,
      degreeType: store.app.tempUnit,
      isInitial: store.app.isInitial,
      isError: store.weather.isError,
    })
  );
  const dispatch = useDispatch();

  useEffect(() => {
    if (isError) {
      console.log('Cannot load weather for this place');
    }
  }, [isError]);

  if (isInitial) return <></>;

  return (
    <div className='weather-container'>
      <div style={{ display: 'flex', justifyContent: 'space-between' }}>
        <h6 className='section-title'>Current Weather</h6>
        <div>
          <ToggleSwitch onClick={() => dispatch(changeTempUnit())} />
        </div>
      </div>
      <div className='current-weather-container'>
        <div className='current-weather-status'>
          <h4>{weather.name}</h4>
          <div style={{ display: 'flex' }}>
            <WeatherIcon code={weather.weather.id} big />
            <span>
              <Temperature value={weather.main.temp} />
              <sup>&deg;</sup>
            </span>
          </div>
          <h6>{weather.weather.description}</h6>
        </div>

        <div className='current-weather-info'>
          <p className='feel-like'>
            Feels like <Temperature value={weather.main.feelsLike} />
            <sup>&deg;</sup>
          </p>
          <div className='high-low-container'>
            <div className='weather-degree'>
              <HighIcon />
              <Temperature value={weather.main.tempMax} />
              <sup>&deg;</sup>
            </div>
            <div className='weather-degree'>
              <LowIcon />
              <Temperature value={weather.main.tempMin} />
              <sup>&deg;</sup>
            </div>
          </div>
          <div className='info-row'>
            <div>
              <HumidityIcon /> Humidity
            </div>
            <span>{weather.main.humidity}%</span>
          </div>
          <div className='info-row'>
            <div>
              <WindIcon /> Wind
            </div>
            <span>
              {degreeType === TempUnit.CELCIUS
                ? weather.wind.speed
                : kmToMile(weather.wind.speed)}
              {degreeType === TempUnit.CELCIUS ? 'kph' : 'mph'}
            </span>
          </div>
          <div className='info-row'>
            <div>
              <PressureIcon /> Pressure
            </div>
            <span>{weather.main.pressure}hPa</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export { CurrentWeather };
