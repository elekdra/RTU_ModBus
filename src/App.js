import React, { useState, useEffect } from 'react';
import { Route, Switch } from 'react-router-dom';

import DetailsScreen from './Pages/DetailsScreen/DetailsScreen';
import TestScreen from './Pages/TestScreen';

import history from './Routing/History';
// all Main Components routes here

const App = () => {
  history.push('/');
  return (
    <div>
      <Switch>
        <Route exact path='/' component={() => <TestScreen />} />
        <Route path='/details' component={() => <DetailsScreen />} />
      </Switch>
    </div>
  );
};

export default App;
