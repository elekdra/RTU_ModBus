import React from 'react';
import BackArrow from '../../../../SharedComponents/BackArrow/BackArrow';
import { useEffect } from 'react';
import { getCPSTypeInfo } from '../../../../Utils/ApiServices';
import './DeviceTypeInfo.css';
const DeviceTypeInfo = (props) => {
  console.log(props);
  function getCPSDeviceTypeInfo() {
    // getCPSTypeInfo().then((value) => {});
  }

  useEffect(() => {
    getCPSDeviceTypeInfo(props.deviceId);
  }, []);
  return (
    <div className='device-type-container'>
      <BackArrow />

      <div>
        <span>Unit Name:</span>
      </div>
      <div>
        <input
          style={{ width: '20em' }}
          className='unit-details'
          type='text'
          disabled
          defaultValue='Intermediate Absorber Acid Cooler'
        />
      </div>
      <div>
        <span> Unit Number:</span>
      </div>
      <div>
        <input
          style={{ width: '10em' }}
          className='unit-details'
          type='text'
          disabled
          value='99F 321'
        />
      </div>
      <div>
        <span> Unit Type:</span>
      </div>
      <div>
        <input
          style={{ width: '10em' }}
          className='unit-details'
          type='text'
          disabled
          value='Cooler'
        />
      </div>
    </div>
  );
};

export default DeviceTypeInfo;
