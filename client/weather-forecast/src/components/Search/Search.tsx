import { ReactComponent as SearchIconSvg } from 'assets/search-icon.svg';
import { ReactComponent as LocationIconSvg } from 'assets/location-icon.svg';
import Suggestion from './Suggestion';
import { DebounceInput } from 'react-debounce-input';
import { useEffect, useRef, useState } from 'react';
import { useDispatch } from 'react-redux';
import { useClickOutside } from 'hooks/useClickOutside';
import { fetchWeather } from 'store/fetchWeather';
import { fetchCities } from 'services/placeSuggestion';
import { ThunkDispatch } from '@reduxjs/toolkit';
import './index.css';
import { PlaceResponse } from 'types/search.interface';

const Search = () => {
  const dispatch = useDispatch<ThunkDispatch<any, any, any>>();
  const suggestionRef = useRef(null);
  const [suggestions, setSuggestions] = useState<PlaceResponse[]>([]);
  const [showSuggestions, setShowSuggestions] = useState(false);
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    if (!searchTerm) {
      return;
    }
    setShowSuggestions(true);
    fetchCities(searchTerm).then((res) => {
      console.log('res ', res);

      setSuggestions(res);
    });
  }, [searchTerm]);

  useClickOutside(suggestionRef, () => setShowSuggestions(false));

  const onSearchInputChanged = (e: any) => {
    setSearchTerm(e.target.value);
  };
  const showPosition = (position: any) => {
    dispatch(
      fetchWeather({
        lat: position.coords.latitude,
        lon: position.coords.longitude,
      })
    );
  };

  return (
    <div className='search'>
      <SearchIconSvg className='search-icon' />
      <DebounceInput
        debounceTimeout={100}
        onChange={onSearchInputChanged}
        placeholder='Search for location'
        className='search-input'
      />
      <button
        className='search-button'
        onClick={() => {
          if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(showPosition);
          } else {
            alert('Geolocation is not supported by this browser.');
          }
        }}
      >
        <LocationIconSvg className='search-location-icon' />
      </button>
      {showSuggestions && (
        <div className='search-result' ref={suggestionRef}>
          {suggestions?.slice(0, 6)?.map((s, i) => (
            <Suggestion
              key={i}
              label={s.name}
              lat={s.lat}
              lon={s.lon}
              hideSuggestionFn={() => {
                setShowSuggestions(false);
              }}
            />
          ))}
        </div>
      )}
    </div>
  );
};

export { Search };
