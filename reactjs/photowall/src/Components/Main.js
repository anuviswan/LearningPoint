import React, { Component } from 'react'
import Title from './Title'
import PhotoWall from './PhotoWall'
import AddPhoto from './AddPhoto'
import { Route, Link } from 'react-router-dom'
import { removePost } from '../redux/actions'

class Main extends Component {

    constructor(props) {
        super();

    }

    render() {
        console.log(this.props);
        return (<div>
            <h1><Link to="/">Photo Wall</Link></h1>
            <Route exact path="/" render={() => (
                <div>
                    <PhotoWall {...this.props} />
                </div>
            )} />
            <Route path="/AddPhoto" render={({ history }) => (
                <AddPhoto {...this.props} onHistory={history} />
            )} />
        </div>)
    }

}

export default Main;