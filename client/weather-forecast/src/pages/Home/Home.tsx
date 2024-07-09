import { CurrentWeather } from 'components/CurrentWeather';
import { Forecast } from 'components/Forecast';
import { Header } from 'components/Header';
import { Search } from 'components/Search';
import { Spinner } from 'components/Spinner';
import { useSelector } from 'react-redux';
import { AppStore } from 'store';

const Home = () => {
  const { loading } = useSelector((state: AppStore) => ({
    loading: state.app.isLoading,
  }));

  return (
    <>
      {loading && <Spinner />}
      <Header />
      <Search />
      <CurrentWeather />
      <Forecast />
    </>
  );
};

export { Home };
