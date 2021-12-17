import logo from './logo.svg';
import './App.css';
import { useState } from 'react';
import Select from 'react-select';
import {
  ReadDatafromAddress,
  WriteDataToAddress,
} from './ApiService/ApiService';
import { Read } from './Mode/Read';
import Write from './Mode/Write';
function App() {
  const listNames = [{ label: 'Read' }, { label: 'Write' }];
  let addressVal, dataVal;
  const [readval, setReadVal] = useState('');
  const [readval2, setReadVal2] = useState('');
  function ReadData() {
    addressVal = document.getElementById('address').value;
    ReadDatafromAddress(addressVal).then((response) => {
      var fullData = response.data;
      let ar = fullData.split('|');
      setReadVal(ar[0]);
      setReadVal2(ar[1]);
    });
  }
  function WriteData() {
    addressVal = document.getElementById('writeaddress').value;
    dataVal = document.getElementById('value').value;
    WriteDataToAddress(addressVal, dataVal).then((response) => {
      var write = response.data;
      alert('Write finished');
    });
  }
  function changemode(value) {
    alert(value.label);
    if (value.label === 'Read') {
    }
  }
  return (
    <div className='App'>
      <center>
        <h1 style={{ fontFamily: 'cursive' }}>ModBus RTU</h1>
        <h3>select the Slave Device</h3>
        <select>
          <option>Slave 1</option>
          <option>Slave 2</option>
        </select>
        <h3>select the type of registers</h3>
        <select>
          <option>Coil Status</option>
          <option>Input Status</option>
          <option>Holding Registers</option>
          <option>Input Registers</option>
        </select>
        <h3>select the Mode</h3>
        <Select
          style={{ width: '1em' }}
          options={listNames}
          onChange={(values) => changemode(values)}
        />
        <div>
          <span>Address:</span>
          <input id='address' type='text' />
          <br />

          <button
            onClick={() => {
              ReadData();
            }}
          >
            Read
          </button>
          <h3>Data in slave address is:</h3>
          <input type='text' value={readval} />
          {/* <h3>Data in slave 2 is:</h3>
          <input type='text' value={readval2} /> */}
        </div>
        {/* 
        <div>
          <h2>Write to a Register</h2>
          <span>Address:</span>
          <input id='writeaddress' type='text' />
          <br />
          <span>Data:</span>
          <input id='value' type='text' />
          <br />
          <button
            onClick={() => {
              WriteData();
            }}
          >
            Write
          </button>
        </div> */}
      </center>
    </div>
  );
}

export default App;
