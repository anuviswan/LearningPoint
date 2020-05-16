import React, { Component } from 'react'
import Photo from './Photo';
import Comments from './Comments'

class Single extends Component {
    render() {
        // const id = this.props.match.params.id;
        // const posts = this.props.posts;
        const { match, posts } = this.props;
        const id = Number(match.params.id);
        const selectedPost = posts.find((post) => post.id === id)
        const comments = this.props.comments[id] || [];
        const index = this.props.posts.findIndex((post) => post.id == id);
        return <div className='single-photo'>
            <Photo post={selectedPost} {...this.props} index={index} />
            <Comments startAddingComments={this.props.startAddingComments} comments={comments} id={id} />
        </div>
    }
}

export default Single;