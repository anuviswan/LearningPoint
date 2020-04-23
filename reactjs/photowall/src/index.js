import React, { Component } from 'react';
import ReactDOM from 'react-dom';

class List extends Component {
  render() {
    return (<ol>
      {this.props.names.map((n, index) => <li key={index}>{n}</li>)}
    </ol>);
  }
}

class Title extends Component {
  render() {
    return (<h1>{this.props.title}</h1>);
  }
}

class Main extends Component {
  render() {
    return (<div>
      <Title title={"Names"} />
      <List names={["jia", "anu", "anu"]} />
      <List names={["sree", "jia", "anu"]} />
    </div>)
  }
}
ReactDOM.render(<Main />, document.getElementById('root'));