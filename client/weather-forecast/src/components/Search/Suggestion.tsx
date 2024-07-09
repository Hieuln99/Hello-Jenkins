import * as React from 'react';
import { useDispatch } from 'react-redux';
import { fetchWeather } from 'store/fetchWeather';
import { ThunkDispatch } from '@reduxjs/toolkit';

interface ISuggestionProps {
  label: string;
  hideSuggestionFn: Function;
  lat: number;
  lon: number;
}

const Suggestion: React.FC<ISuggestionProps> = (props) => {
  const dispatch = useDispatch<ThunkDispatch<any, any, any>>();

  const onClick = () => {
    dispatch(fetchWeather({ lat: props.lat, lon: props.lon }));
    setTimeout(() => {
      props.hideSuggestionFn();
    }, 400);
  };

  return (
    <a href='/#' className='search-result-item' onClick={onClick}>
      {props.label}
    </a>
  );
};

export default Suggestion;
