import React from 'react';
import { useHistory } from 'react-router-dom';
const TestScreen = () => {
  let history = useHistory();
  function moveToDetails() {
    history.push('/details', { deviceId: '1' });
  }

  return (
    <div>
      <button onClick={moveToDetails}>Details</button>
    </div>
  );
};

export default TestScreen;
