import React, { Component } from 'react';
import Photo from './Photo'
import PropTypes from 'prop-types'
import { Link } from 'react-router-dom'

class PhotoWall extends Component {

    render() {
        return <div>
            <Link className="addIcon" to="/AddPhoto">.</Link>
            {/* <a className="addIcon" onClick={this.props.onNavigate} href="#AddPhoto">.</a> */}
            {/* <button className="addIcon" onClick={this.props.onNavigate} /> */}
            <div className="photoGrid">
                {this.props
                    .posts
                    .sort((x, y) => (y.id - x.id))
                    .map((post, index) => <Photo key={post.id} post={post} onRemovePhoto={this.props.onRemovePhoto} />)}
            </div>
        </div >;
    }
}

PhotoWall.propTypes = {
    posts: PropTypes.array.isRequired
}


export default PhotoWall;