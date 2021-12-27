import axios from 'axios';

const getCPSTypeInfo = (id) => {
  const response = axios.get(
    'http://localhost:5000/api/devicedetails/devicetype/?ID=' + id
  );

  console.log(response);
  return response;
};

const getCPSDetails = (id) => {
  const response = axios.get(
    'http://localhost:5000/api/devicedetails/devicedetails/?ID=' + id
  );

  console.log(response);
  return response;
};

export { getCPSTypeInfo, getCPSDetails };
