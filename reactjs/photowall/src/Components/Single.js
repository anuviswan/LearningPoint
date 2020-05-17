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
        if (this.props.loading == true) {
            return <div className='loader'>...loading</div>
        }
        else if (posts) {
            return <div className='single-photo'>
                <Photo post={selectedPost} {...this.props} index={index} />
                <Comments startAddingComments={this.props.startAddingComments} comments={comments} id={id} />
            </div>
        }
        else {
            return <h1>No Post Found</h1>
        }

    }
}

export default Single;