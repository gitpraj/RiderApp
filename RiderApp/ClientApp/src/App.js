import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { AddRider } from './components/AddRider';
import { UpdateRider } from './components/UpdateRider';
import { Riders } from './components/Riders';


export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
            <Route exact path='/' component={Home} />
            <Route exact path='/addrider' component={AddRider} />
            <Route exact path='/updaterider' component={UpdateRider} />
            <Route exact path='/riders' component={Riders} />
      </Layout>
    );
  }
}
