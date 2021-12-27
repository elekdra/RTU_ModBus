import React from 'react';
import Arrow from '../../Assets/Images/logo-arrow.png';
import './BackArrow.css';
import { useHistory } from 'react-router';
const BackArrow = () => {
  let history = useHistory();
  function routeToOverView() {
    history.push('/');
  }
  return (
    <div>
      <button className='back-arrow-button' onClick={routeToOverView}>
        <img className='arrow-image' src={Arrow} alt='arrow' />
      </button>
    </div>
  );
};

export default BackArrow;
