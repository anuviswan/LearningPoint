import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import Main from './Components/Main';
import './styles/stylesheet.css';
import { BrowserRouter } from 'react-router-dom'

ReactDOM.render(<BrowserRouter><Main /></BrowserRouter>, document.getElementById('root'));