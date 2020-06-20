import React, { Component } from 'react';
import PropTypes from 'prop-types';

export class Search extends Component {
  state = {
    text: '',
  };

  onChange = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };

  onSubmit = (e) => {
    e.preventDefault();
    if (this.state.text == '') {
      this.props.setAlert('Please enter a valid value', 'light');
    } else {
      this.props.searchUsers(this.state.text);
      this.setState({ text: '' });
    }
  };

  static propTypes = {
    searchUsers: PropTypes.func.isRequired,
    clearUsers: PropTypes.func.isRequired,
    showClear: PropTypes.bool.isRequired,
    setAlerts: PropTypes.func,
  };

  render() {
    const { showClear, clearUsers } = this.props;
    return (
      <div>
        <form className='form' onSubmit={this.onSubmit}>
          <input
            type='text'
            name='text'
            placeholder='Search Users'
            value={this.state.text}
            onChange={this.onChange}
          />
          <input type='submit' value='Search' className='btn-dark btn-block' />
        </form>
        {showClear && (
          <button className='btn btn-light btn-block' onClick={clearUsers}>
            Clear Users
          </button>
        )}
      </div>
    );
  }
}

export default Search;
