import axios from 'axios';

const ReadDatafromAddress = (slave, register, address) => {
  console.log('filter the data');
  let ApiUrl =
    'http://localhost:5000/api/ModBusRtuCommand/getreaddata/?address=' +
    slave +
    '|' +
    register +
    '|' +
    address;
  let DefaultValue = axios.get(ApiUrl);
  console.log(DefaultValue);
  return DefaultValue;
};

const WriteDataToAddress = (slaveId, registerId, address, data) => {
  let ApiUrl =
    'http://localhost:5000/api/ModBusRtuCommand/setdata/?address=' +
    slaveId +
    '|' +
    registerId +
    '|' +
    address +
    '|' +
    data;
  let DefaultValue = axios.get(ApiUrl);
  console.log(DefaultValue);
  return DefaultValue;
};

const GetPorts = () => {
  let ApiUrl = 'http://localhost:5000/api/ModBusRtuCommand/getPorts';
  let DefaultValue = axios.get(ApiUrl);
  console.log(DefaultValue);
  return DefaultValue;
};

export { GetPorts, ReadDatafromAddress, WriteDataToAddress };
