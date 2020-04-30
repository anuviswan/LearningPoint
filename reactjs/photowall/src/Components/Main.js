import React, { Component } from 'react'
import Title from './Title'
import PhotoWall from './PhotoWall'
import AddPhoto from './AddPhoto'
import { Route } from 'react-router-dom'

class Main extends Component {

    constructor(props) {
        super();

    }

    render() {
        return (<div>
            <Route exact path="/" render={() => (
                <div>
                    <Title title={"Photo Wall"} />
                    <PhotoWall posts={this.props.posts} />
                    {/* <PhotoWall posts={this.props.posts}
                        onRemovePhoto={this.removePhoto}
                        onNavigate={this.navigate} /> */}
                </div>
            )} />
            {/* <Route path="/AddPhoto" render={({ history }) => (
                <AddPhoto onAddPhoto={(addedPhoto) => {
                    this.addPhoto(addedPhoto);
                    history.push('/');
                }} />
            )} /> */}
        </div>)
    }

}

export default Main;