import React, { Component } from 'react'
import Title from './Title'
import PhotoWall from './PhotoWall'
import AddPhoto from './AddPhoto'
import { Route } from 'react-router-dom'
import { removePost } from '../redux/actions'

class Main extends Component {

    constructor(props) {
        super();

    }

    componentDidMount() {
        this.props.removePost(1);
    }

    render() {
        console.log(this.props);
        return (<div>
            <Route exact path="/" render={() => (
                <div>
                    <Title title={"Photo Wall"} />
                    <PhotoWall {...this.props} />
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