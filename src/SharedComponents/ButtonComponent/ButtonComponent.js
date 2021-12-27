import React from 'react';
import './ButtonComponent.css';
const ButtonComponent = (props) => {
  if (props.title === '') {
    return (
      <div className='button-cls'>
        <button className='save'>SAVE</button>
        <button className='reset'>CANCEL</button>
      </div>
    );
  } else {
    return <div></div>;
  }
};

export default ButtonComponent;
