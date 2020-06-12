import React, { Component } from 'react';
import './App.css';
import { render } from '@testing-library/react';
import Navbar from './components/layout/Navbar';
import UserItem from './components/users/UserItem';

class App extends Component {
  render() {
    return (
      <div className='App'>
        <Navbar title='Github Finder' icon='fab fa-github' />
        <UserItem />
      </div>
    );
  }
}

export default App;
