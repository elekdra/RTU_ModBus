import logo from './logo.svg';
import './App.css';
import {
  ReadDatafromAddress,
  WriteDataToAddress,
} from './ApiService/ApiService';
function App() {
  let addressVal, dataVal;
  function ReadData() {
    addressVal = document.getElementById('address').value;
    ReadDatafromAddress(addressVal);
  }
  function WriteData() {
    addressVal = document.getElementById('writeaddress').value;
    dataVal = document.getElementById('value').value;
    WriteDataToAddress(addressVal, dataVal);
  }
  return (
    <div className='App'>
      <center>
        <h1 style={{ fontFamily: 'cursive' }}>ModBus RTU</h1>

        <div>
          <h2>Read From a Register</h2>
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
          <h3>Data is:</h3>
          <input type='text' />
        </div>
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
        </div>
      </center>
    </div>
  );
}

export default App;
