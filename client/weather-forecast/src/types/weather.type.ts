export type WeatherData = {
  weather: {
    id: number;
    main: string;
    description: string;
    icon: string;
  };
  main: {
    temp: number;
    feelsLike: number;
    tempMin: number;
    tempMax: number;
    pressure: number;
    humidity: number;
  };
  wind: {
    speed: number;
    deg: number;
  };
  sys: {
    country: string;
    sunrise: number;
    sunset: number;
  };
  name: string;
};

export type ExtendedForecastData = {
  day: string;
  temp: {
    tempMin: number;
    tempMax: number;
  };
  weather: {
    id: number;
    main: string;
  };
};
