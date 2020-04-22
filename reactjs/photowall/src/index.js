import React from 'react';
import ReactDOM from 'react-dom';

const names = ['Jia', 'Sree', 'Anu'];
const element = React.createElement('ol', null,
  names.map((name, index) => React.createElement('li', { key: index }, name))
);
ReactDOM.render(element, document.getElementById('root'));