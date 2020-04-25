import React, { Component } from 'react'

class Photo extends Component {
    render() {
        const post = this.props.post;

        return <div className='photoGrid'>
            <figure className="figure">
                <img className="photo" src={post.imageLink} alt={post.description} />
                <figurecaption>
                    <p>{post.description}</p>
                </figurecaption>
                <div className="button-container">
                    <button className="remove-button">Remove</button>
                </div>
            </figure>
        </div>;
    }
}

export default Photo;