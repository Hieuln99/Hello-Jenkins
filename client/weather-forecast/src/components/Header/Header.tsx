import weather from 'assets/images/weather.png';
import './index.css';

const Header = () => {
  return (
    <header className='header'>
      <img className='header-img' src={weather} alt='' />
      <h1 className='header-text'>Weather</h1>
    </header>
  );
};

export { Header };
