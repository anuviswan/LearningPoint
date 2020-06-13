import React, { Component } from 'react';
import './App.css';
import { render } from '@testing-library/react';
import Navbar from './components/layout/Navbar';
import Users from './components/users/Users';

class App extends Component {
  render() {
    return (
      <div className='App'>
        <Navbar title='Github Finder' icon='fab fa-github' />
        <div className='container'>
          <Users />
        </div>
      </div>
    );
  }
}

export default App;
