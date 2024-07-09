import './index.css';
import { useState } from 'react';

interface IToggleSwitchProps {
  onClick: Function;
}

const ToggleSwitch = (props: IToggleSwitchProps) => {
  const [toggled, setToggled] = useState(false);
  return (
    <label
      className='switch'
      onClick={() => {
        setToggled((checked) => !checked);
        props.onClick();
      }}
    >
      {toggled && <span className='on'>C</span>}
      {!toggled && <span className='off'>F</span>}
      <div
        className='slider'
        style={{
          transform: toggled ? ' translateX(28px)' : ' translateX(0px)',
        }}
      ></div>
    </label>
  );
};

export { ToggleSwitch };
