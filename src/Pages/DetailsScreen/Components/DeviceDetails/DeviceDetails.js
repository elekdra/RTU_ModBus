import React, { useState } from 'react';
import './DeviceDetails.css';
import line from '../../../../Assets/Images/line.png';
import ButtonComponent from '../../../../SharedComponents/ButtonComponent/ButtonComponent';
import { useEffect } from 'react';
import { getCPSDetails } from '../../../../Utils/ApiServices';
const DeviceDetails = (props) => {
  const [cathodeCurrent, setCathodeCurrent] = useState(0);
  const [cathodeVolt, setcathodeVolt] = useState(0);
  const [controlElectrodeVolt, setControlElectrodeVolt] = useState(0);
  const [deviceId, setDeviceId] = useState(0);
  const [refElectrodeVolt1, setRefElectrodeVolt1] = useState(0);
  const [refElectrodeVolt2, setRefElectrodeVolt2] = useState(0);
  const [refElectrodeVolt3, setRefElectrodeVolt3] = useState(0);
  const [refElectrodeVolt4, setRefElectrodeVolt4] = useState(0);
  const [refElectrodeVolt5, setRefElectrodeVolt5] = useState(0);
  const [refElectrodeVolt6, setRefElectrodeVolt6] = useState(0);
  const [refElectrodeVolt7, setRefElectrodeVolt7] = useState(0);

  function getCPSDeviceDetails() {
    getCPSDetails(props.deviceId).then((value) => {
      console.log(value.data[0]);
      let detailsArray = value.data[0];
      console.log(detailsArray.deviceId);
      setCathodeCurrent(detailsArray.cathodeCurrent);
      setcathodeVolt(detailsArray.cathodeVolt);
      setControlElectrodeVolt(detailsArray.controlElectrodeVolt);
      setDeviceId(detailsArray.deviceId);
      setRefElectrodeVolt3(detailsArray.refElectrodeVolt3);
      setRefElectrodeVolt2(detailsArray.refElectrodeVolt2);
      setRefElectrodeVolt4(detailsArray.refElectrodeVolt4);
      setRefElectrodeVolt6(detailsArray.refElectrodeVolt6);
      setRefElectrodeVolt7(detailsArray.refElectrodeVolt7);
      setRefElectrodeVolt5(detailsArray.refElectrodeVolt5);
      setRefElectrodeVolt1(detailsArray.refElectrodeVolt1);
    });
  }
  useEffect(() => {
    getCPSDeviceDetails();
  }, []);
  const cathodeCurrUnit = 'A';
  const cathodeVoltUnit = 'V';
  const cathodeCEVoltUnit = 'mA';

  return (
    <div className='device-details-container'>
      <div className='device-details'>
        <center>
          <div className='cathode-details'>
            <div>
              <span>
                Cathode Current
                <div>
                  <input
                    style={{ width: '10em' }}
                    className='cathode-values'
                    value={cathodeCurrent}
                  />
                  <input
                    style={{ width: '5em' }}
                    className='cathode-unit'
                    defaultValue={cathodeCurrUnit}
                  />
                </div>
              </span>
            </div>
            <div>
              <span>
                Cathode Voltage
                <div>
                  <input
                    style={{ width: '10em' }}
                    className='cathode-values'
                    value={cathodeVolt}
                  />
                  <input
                    style={{ width: '5em' }}
                    className='cathode-unit'
                    defaultValue={cathodeVoltUnit}
                  />
                </div>
              </span>
            </div>
            <div>
              <span>
                Cathode Electrode Voltage
                <div>
                  <input
                    style={{ width: '10em' }}
                    className='cathode-values'
                    value={controlElectrodeVolt}
                  />
                  <input
                    style={{ width: '5em' }}
                    className='cathode-unit'
                    defaultValue={cathodeCEVoltUnit}
                  />
                </div>
              </span>
            </div>
          </div>
          <div className='re-details'>
            <div>
              {' '}
              <span>
                RE 01
                <input
                  style={{ width: '10em' }}
                  className='cathode-values'
                  value={refElectrodeVolt1}
                />
                <input
                  style={{ width: '5em' }}
                  className='cathode-unit'
                  defaultValue={cathodeCEVoltUnit}
                />
              </span>
              <br />
              <span>
                RE 02
                <input
                  style={{ width: '10em' }}
                  className='cathode-values'
                  value={refElectrodeVolt2}
                />
                <input
                  style={{ width: '5em' }}
                  className='cathode-unit'
                  defaultValue={cathodeCEVoltUnit}
                />
              </span>{' '}
              <br />
              <span>
                RE 03
                <input
                  style={{ width: '10em' }}
                  className='cathode-values'
                  value={refElectrodeVolt3}
                />
                <input
                  style={{ width: '5em' }}
                  className='cathode-unit'
                  defaultValue={cathodeCEVoltUnit}
                />
              </span>{' '}
              <br />
              <span>
                RE 04
                <input
                  style={{ width: '10em' }}
                  className='cathode-values'
                  value={refElectrodeVolt4}
                />
                <input
                  style={{ width: '5em' }}
                  className='cathode-unit'
                  defaultValue={cathodeCEVoltUnit}
                />
              </span>
            </div>
            <div>
              <img className='divider-line' src={line} alt='' />
            </div>
            <div>
              <span>
                RE 05
                <input
                  style={{ width: '10em' }}
                  className='cathode-values'
                  value={refElectrodeVolt5}
                />
                <input
                  style={{ width: '5em' }}
                  className='cathode-unit'
                  defaultValue={cathodeCEVoltUnit}
                />
              </span>{' '}
              <br />
              <span>
                RE 06
                <input
                  style={{ width: '10em' }}
                  className='cathode-values'
                  value={refElectrodeVolt6}
                />
                <input
                  style={{ width: '5em' }}
                  className='cathode-unit'
                  defaultValue={cathodeCEVoltUnit}
                />
              </span>{' '}
              <br />
              <span>
                RE 07
                <input
                  style={{ width: '10em' }}
                  className='cathode-values'
                  value={refElectrodeVolt7}
                />
                <input
                  style={{ width: '5em' }}
                  className='cathode-unit'
                  defaultValue={cathodeCEVoltUnit}
                />
              </span>
            </div>
          </div>
          <div>
            {' '}
            <ButtonComponent title={props.title} />
          </div>
        </center>
      </div>
    </div>
  );
};

export default DeviceDetails;
