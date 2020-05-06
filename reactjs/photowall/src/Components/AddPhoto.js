import React, { Component } from 'react'
import Photo from './Photo';

class AddPhoto extends Component {

    constructor() {
        super();
        this.handleSubmit = this.handleSubmit.bind(this);
    }
    handleSubmit(eventArgs) {
        eventArgs.preventDefault();
        const imageLink = eventArgs.target.elements.link.value;
        const description = eventArgs.target.elements.description.value;
        const post = {
            id: Number(new Date()),
            description: description,
            imageLink: imageLink
        };

        if (imageLink && description) {
            this.props.addPost(post);
            this.props.onHistory.push('/');
        }
    }
    render() {
        return (
            <div>
                <h1>Photo Wall</h1>
                <div className="form">
                    <form onSubmit={this.handleSubmit}>
                        <input type="text" placeholder="Link" name="link" />
                        <input type="text" placeholder="Description" name="description" />
                        <button>Add Photo</button>
                    </form>
                </div>
            </div>
        )
    }
}


export default AddPhoto