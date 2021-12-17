import logo from './logo.svg';
import './App.css';
import { useState, useEffect } from 'react';
import Select from 'react-select';
import {
  ReadDatafromAddress,
  WriteDataToAddress,
  GetPorts,
} from './ApiService/ApiService';
import { Read } from './Mode/Read';
import Write from './Mode/Write';
function App() {
  const listNames = [{ label: 'Read' }, { label: 'Write' }];
  const RegisterNames = [
    { label: 'Coil Status' },
    { label: 'Input Status' },
    { label: 'Holding Registers' },
    { label: 'Input Registers' },
  ];
  const SlaveNames = [{ label: 'Slave 1' }, { label: 'Slave 2' }];
  let addressVal, dataVal;
  const [readval, setReadVal] = useState('');
  const [readval2, setReadVal2] = useState('');
  const [mode, setMode] = useState('');
  const [slaveId, setSlaveId] = useState('');
  const [registerId, setRegisterId] = useState('');
  const [device, setDevice] = useState(0);

  function getPorts() {
    GetPorts().then((response) => {
      var deviceno = response.data;
      setDevice(deviceno);
    });
  }
  useEffect(() => {
    getPorts();
  }, []);
  function ReadData() {
    addressVal = document.getElementById('address').value;

    ReadDatafromAddress(slaveId, registerId, addressVal).then((response) => {
      var fullData = response.data;

      setReadVal(fullData);
    });
  }
  function WriteData() {
    addressVal = document.getElementById('address').value;
    dataVal = document.getElementById('value').value;

    WriteDataToAddress(slaveId, registerId, addressVal, dataVal).then(
      (response) => {
        var write = response.data;
        if (response.data === 'Invalid Operation') {
          alert(response.data);
        } else {
          alert('Write finished');
        }
      }
    );
  }
  function changemode(value) {
    if (value.label === 'Read') {
      document.getElementById('data-container').style.visibility = 'hidden';
      document.getElementById('result').style.visibility = 'visible';
      setMode('Read');
    } else {
      document.getElementById('data-container').style.visibility = 'visible';
      document.getElementById('result').style.visibility = 'hidden';
      setMode('Write');
    }
  }
  function changeslave(value) {
    setSlaveId(value.label);
  }
  function changeRegister(value) {
    setRegisterId(value.label);
  }
  return (
    <div className='App'>
      <center>
        <h1 style={{ fontFamily: 'cursive' }}>ModBus RTU</h1>
        <br />
        <input type='text' value={device} />
        <h3>select the Slave Device</h3>

        <Select
          style={{ width: '1em' }}
          options={SlaveNames}
          id='slaveid'
          onChange={(values) => changeslave(values)}
        />
        <h3>select the type of registers</h3>

        <Select
          style={{ width: '1em' }}
          options={RegisterNames}
          id='registerid'
          onChange={(values) => changeRegister(values)}
        />

        <h3>select the Mode</h3>
        <Select
          style={{ width: '1em' }}
          options={listNames}
          id='modeid'
          onChange={(values) => changemode(values)}
        />
        <br />
        <br />
        <div>
          <span>Address:</span>
          <input id='address' type='text' />
          <br /> <br />
        </div>
        <div id='data-container'>
          <span>Data:</span>
          <input id='value' type='text' />
          <br /> <br />
        </div>
        <div>
          <button
            onClick={() => {
              if (mode === 'Read') {
                ReadData();
              } else {
                WriteData();
              }
            }}
          >
            Submit
          </button>
          <br />
          <div id='result'>
            <h3>Data in slave address is:</h3>
            <input type='text' value={readval} />
          </div>
        </div>
      </center>
    </div>
  );
}

export default App;
