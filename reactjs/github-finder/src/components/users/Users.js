import React from 'react';
import UserItem from './UserItem';
import Spinner from '../layout/Spinner';
import PropTypes from 'prop-types';

const Users = ({ users, loading }) => {
  const isUsersLoaded = users.length > 0;
  return (
    <div style={userStyle}>
      {isUsersLoaded ? (
        users.map((user) => <UserItem key={user.id} user={user} />)
      ) : (
        <Spinner />
      )}
    </div>
  );
};
Users.protoType = {
  users: PropTypes.array.isRequired,
  loading: PropTypes.bool.isRequired,
};
const userStyle = {
  display: 'grid',
  gridTemplateColumns: 'repeat(3, 1fr)',
  gridGap: '1rem',
};
export default Users;
