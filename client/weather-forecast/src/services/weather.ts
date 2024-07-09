const baseUrl = 'http://localhost:5001';

export const fetchWeatherData = async (
  city: string | { lat: number; lon: number }
) => {
  console.log(city);

  let url = '';
  if (typeof city === 'object') {
    url = `${baseUrl}/current-weather?lat=${city.lat}&lon=${city.lon}`;
  }

  // if (typeof city === 'object') {
  //   url = `${baseUrl}/weather?lat=${city.lat}&lon=${city.lng}&appid=${process.env.REACT_APP_WEATHER_API_KEY}`;
  // }
  // return await (await fetch(url)).json();

  const result = {
    main: {
      temp: 306.16,
      feelsLike: 310.05,
      tempMin: 306.16,
      tempMax: 306.16,
      pressure: 1007,
      humidity: 52,
    },
    name: 'Hanoi',
    sys: {
      country: 'VN',
      sunrise: 1717193700,
      sunset: 1717241700,
    },
    weather: [
      {
        id: 800,
        main: 'Clear',
        description: 'clear sky',
        icon: '01d',
      },
    ],
    wind: {
      speed: 2.57,
      deg: 80,
    },
    clouds: {
      all: 0,
    },
    cod: 200,
  };

  return result;
};

export const fetchExtendedForecastData = async (
  city: string | { lat: number; lon: number }
) => {
  let url = '';
  if (typeof city === 'object') {
    url = `${baseUrl}/weather-forecast?lat=${city.lat}&lon=${city.lon}`;
  }

  // return await (await fetch(url)).json();
  const result = {
    list: [
      {
        main: {
          tempMin: 306.39,
          tempMax: 306.86,
        },
        weather: [
          {
            id: 802,
            main: 'Clouds',
          },
        ],
      },
      {
        dt: '1717243200',
        main: {
          temp: 303.89,
          feelsLike: 308.43,
          tempMin: 302.75,
          tempMax: 303.89,
          pressure: 1006,
          humidity: 64,
          seaLevel: 1006,
          grndLevel: 1004,
          tempKf: 1.14,
        },
        weather: [
          {
            id: 803,
            main: 'Clouds',
            description: 'broken clouds',
            icon: '04n',
          },
        ],
        clouds: {
          all: 67,
        },
        wind: {
          speed: 3.64,
          deg: 127,
          gust: 6.89,
        },
        visibility: 10000,
        pop: 0.14,
        rain: null,
        sys: {
          type: null,
          id: null,
          country: null,
          sunrise: null,
          sunset: null,
          pod: 'n',
        },
        dtTxt: '2024-06-01 12:00:00',
      },
      {
        dt: '1717254000',
        main: {
          temp: 300.64,
          feelsLike: 304.13,
          tempMin: 300.64,
          tempMax: 300.64,
          pressure: 1008,
          humidity: 81,
          seaLevel: 1008,
          grndLevel: 1006,
          tempKf: 0,
        },
        weather: [
          {
            id: 804,
            main: 'Clouds',
            description: 'overcast clouds',
            icon: '04n',
          },
        ],
        clouds: {
          all: 98,
        },
        wind: {
          speed: 3.47,
          deg: 133,
          gust: 6.88,
        },
        visibility: 10000,
        pop: 0.05,
        rain: null,
        sys: {
          type: null,
          id: null,
          country: null,
          sunrise: null,
          sunset: null,
          pod: 'n',
        },
        dtTxt: '2024-06-01 15:00:00',
      },
      {
        dt: '1717264800',
        main: {
          temp: 299.68,
          feelsLike: 299.68,
          tempMin: 299.68,
          tempMax: 299.68,
          pressure: 1007,
          humidity: 84,
          seaLevel: 1007,
          grndLevel: 1005,
          tempKf: 0,
        },
        weather: [
          {
            id: 804,
            main: 'Clouds',
            description: 'overcast clouds',
            icon: '04n',
          },
        ],
        clouds: {
          all: 97,
        },
        wind: {
          speed: 3.01,
          deg: 131,
          gust: 6.46,
        },
        visibility: 10000,
        pop: 0.19,
        rain: null,
        sys: {
          type: null,
          id: null,
          country: null,
          sunrise: null,
          sunset: null,
          pod: 'n',
        },
        dtTxt: '2024-06-01 18:00:00',
      },
      {
        dt: '1717275600',
        main: {
          temp: 298.98,
          feelsLike: 299.86,
          tempMin: 298.98,
          tempMax: 298.98,
          pressure: 1006,
          humidity: 86,
          seaLevel: 1006,
          grndLevel: 1004,
          tempKf: 0,
        },
        weather: [
          {
            id: 804,
            main: 'Clouds',
            description: 'overcast clouds',
            icon: '04n',
          },
        ],
        clouds: {
          all: 99,
        },
        wind: {
          speed: 2.1,
          deg: 110,
          gust: 3.83,
        },
        visibility: 10000,
        pop: 0.04,
        rain: null,
        sys: {
          type: null,
          id: null,
          country: null,
          sunrise: null,
          sunset: null,
          pod: 'n',
        },
        dtTxt: '2024-06-01 21:00:00',
      },
      {
        dt: '1717286400',
        main: {
          temp: 300.56,
          feelsLike: 304.06,
          tempMin: 300.56,
          tempMax: 300.56,
          pressure: 1007,
          humidity: 82,
          seaLevel: 1007,
          grndLevel: 1006,
          tempKf: 0,
        },
        weather: [
          {
            id: 804,
            main: 'Clouds',
            description: 'overcast clouds',
            icon: '04d',
          },
        ],
        clouds: {
          all: 92,
        },
        wind: {
          speed: 1.89,
          deg: 110,
          gust: 2.77,
        },
        visibility: 10000,
        pop: 0.03,
        rain: null,
        sys: {
          type: null,
          id: null,
          country: null,
          sunrise: null,
          sunset: null,
          pod: 'd',
        },
        dtTxt: '2024-06-02 00:00:00',
      },
      {
        dt: '1717297200',
        main: {
          temp: 303.77,
          feelsLike: 310.03,
          tempMin: 303.77,
          tempMax: 303.77,
          pressure: 1007,
          humidity: 71,
          seaLevel: 1007,
          grndLevel: 1006,
          tempKf: 0,
        },
        weather: [
          {
            id: 804,
            main: 'Clouds',
            description: 'overcast clouds',
            icon: '04d',
          },
        ],
        clouds: {
          all: 97,
        },
        wind: {
          speed: 2.3,
          deg: 141,
          gust: 2.79,
        },
        visibility: 10000,
        pop: 0.08,
        rain: null,
        sys: {
          type: null,
          id: null,
          country: null,
          sunrise: null,
          sunset: null,
          pod: 'd',
        },
        dtTxt: '2024-06-02 03:00:00',
      },
    ],
  };

  return result;
};
