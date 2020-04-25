import React, { Component } from 'react'

class List extends Component {
    render() {
        return (<ol>
            {this.props.names.map((n, index) => <li key={index}>{n}</li>)}
        </ol>);
    }
}

export default List;