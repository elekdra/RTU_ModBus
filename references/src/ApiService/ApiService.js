import axios from 'axios';

const ReadDatafromAddress = (address) => {
  console.log('filter the data');
  let ApiUrl =
    'http://localhost:5000/api/ModBusRtuCommand/getreaddata/?address=' +
    address;
  let DefaultValue = axios.get(ApiUrl);
  console.log(DefaultValue);
  return DefaultValue;
};

const WriteDataToAddress = (address, data) => {
  let ApiUrl =
    'http://localhost:5000/api/ModBusRtuCommand/setdata/?address=' +
    address +
    '|' +
    data;
  let DefaultValue = axios.get(ApiUrl);
  console.log(DefaultValue);
  return DefaultValue;
};

export { ReadDatafromAddress, WriteDataToAddress };
