import React, { useState } from 'react';
import Alarm from '../../../../SharedComponents/Alarm/Alarm';
import cosasco from '../../../../Assets/Images/logo-01.png';
import './MainHeaderTab.css';
const MainHeaderTab = (props) => {
  console.log(props);

  return (
    <div className='main-header'>
      <img className='cosasco-header' src={cosasco} alt='cosasco' />
      <Alarm status={props.title} />
    </div>
  );
};

export default MainHeaderTab;
