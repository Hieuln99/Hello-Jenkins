import Temperature from 'components/CurrentWeather/Temperature';
import WeatherIcon from 'components/CurrentWeather/WeatherIcon';

interface IForecastItemProps {
  day: string;
  weatherCode: number;
  high: number;
  low: number;
  main: string;
}

const ForecastItem = (props: IForecastItemProps) => {
  return (
    <div className='forecast-item-container'>
      <h6>{props.day}</h6>
      <WeatherIcon code={props.weatherCode} />
      <p>{props.main}</p>
      <span>
        <Temperature value={props.high} />
        <sup>&deg;</sup>
        <small>/</small>
        <Temperature value={props.low} />
        <sup>&deg;</sup>
      </span>
    </div>
  );
};

export { ForecastItem };
