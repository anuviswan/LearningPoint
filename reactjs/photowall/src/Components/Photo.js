import React, { Component } from 'react'
import PropTypes from 'prop-types'
import { Link } from 'react-router-dom'

class Photo extends Component {
    render() {
        const post = this.props.post;
        console.log(this.props.index);
        return <div className='photoGrid'>
            <Link to={`Single/${post.id}`}>
                <img className="photo" src={post.imageLink} alt={post.description} />
            </Link>
            <figure className="figure">
                <figcaption>
                    <p>{post.description}</p>
                </figcaption>
                <div className="button-container">
                    <button className="remove-button" onClick={() => {
                        this.props.removePost(this.props.index);
                        this.props.history.push('/')
                    }}>Remove</button>
                    <Link to={`Single/${post.id}`} className="button">
                        <div className='comment-count'>
                            <div className='speech-bubble'></div>
                            {this.props.comments[post.id] ? this.props.comments[post.id].length : 0}
                        </div>
                    </Link>
                </div>

            </figure>
        </div>;
    }
}

Photo.propTypes = {
    post: PropTypes.object.isRequired,
}

export default Photo;