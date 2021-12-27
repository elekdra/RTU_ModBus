import React from 'react';
import alarm from '../../Assets/Images/logo-alarm.png';
import './Alarm.css';
const Alarm = (props) => {
  if (props.status !== '') {
    return (
      <div className='alarm'>
        <div>
          <img src={alarm} alt='logo-alarm' />
        </div>
        <div className='alarm-status'> {props.status}</div>
      </div>
    );
  } else {
    return null;
  }
};

export default Alarm;
