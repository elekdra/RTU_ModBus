import React from 'react';
import DeviceDetails from './Components/DeviceDetails/DeviceDetails';
import DeviceTypeInfo from './Components/DeviceTypeInfo/DeviceTypeInfo';
import MainHeaderTab from './Components/MainHeaderTab/MainHeaderTab';
import './DetailsScreen.css';
import { useLocation } from 'react-router-dom';
const DetailsScreen = () => {
  let location = useLocation();
  console.log(location.state);
  let deviceId = location.state.deviceId;
  return (
    <div className='details-screen'>
      <MainHeaderTab title='CE High' />
      <DeviceTypeInfo deviceId={deviceId} />
      <DeviceDetails deviceId={deviceId} />
    </div>
  );
};

export default DetailsScreen;
