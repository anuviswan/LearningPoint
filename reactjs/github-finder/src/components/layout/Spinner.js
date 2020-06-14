import React, { Fragment } from 'react';
import spinner from './spinner.gif';

const Spinner = () => {
  return (
    <Fragment>
      <image src={spinner} alt='loading...' style={userStyle} />
    </Fragment>
  );
};

const userStyle = {
  width: '200px',
  margin: 'auto',
  display: 'block',
};
export default Spinner;
