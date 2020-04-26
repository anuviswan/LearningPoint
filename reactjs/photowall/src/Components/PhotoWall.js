import React, { Component } from 'react';
import Photo from './Photo'
import PropTypes from 'prop-types'


class PhotoWall extends Component {

    render() {
        return <div>
            <a className="addIcon" onClick={this.props.onNavigate} href="#AddPhoto">.</a>
            {/* <button className="addIcon" onClick={this.props.onNavigate} /> */}
            <div>
                {this.props.posts.map((post, index) => <Photo key={index} post={post} onRemovePhoto={this.props.onRemovePhoto} />)}
            </div>
        </div >;
    }
}

PhotoWall.propTypes = {
    posts: PropTypes.array.isRequired,
    onRemovePhoto: PropTypes.func.isRequired
}


export default PhotoWall;