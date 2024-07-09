import { useSelector } from 'react-redux';
import { AppStore } from 'store';
import { ForecastItem } from './ForecastItem';
import './index.css';

const Forecast = () => {
  const { forecast, isInitial } = useSelector((state: AppStore) => ({
    loading: state.app.isLoading,
    isInitial: state.app.isInitial,
    forecast: state.weather.extendedWeatherData,
  }));

  if (isInitial) return <></>;

  return (
    <div className='forecast-container'>
      <h6 className='forecast-section-title'>Extended Forecast</h6>
      <div className='forecast-items'>
        {forecast.map((item, i) => {
          return (
            <ForecastItem
              key={i}
              day={item.day}
              high={item.temp.tempMax}
              low={item.temp.tempMin}
              weatherCode={item.weather.id}
              main={item.weather.main}
            />
          );
        })}
      </div>
    </div>
  );
};

export { Forecast };
