import React, { Component } from 'react';
import Photo from './Photo'
import PropTypes from 'prop-types'


class PhotoWall extends Component {

    render() {
        return <div>
            {this.props.posts.map((post, index) => <Photo key={index} post={post} onRemovePhoto={this.props.onRemovePhoto} />)}
        </div>;
    }
}

PhotoWall.propTypes = {
    posts: PropTypes.array.isRequired,
    onRemovePhoto: PropTypes.func.isRequired
}


export default PhotoWall;