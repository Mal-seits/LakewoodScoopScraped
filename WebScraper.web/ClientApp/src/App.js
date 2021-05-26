import React, { Component } from 'react';
import { Route } from 'react-router';
import Layout from './Components/Layout';
import Home from './Pages/Home';

export default class App extends Component {

  render () {
    return (
      <Layout>
          <Route exact path ='/' component={Home} />
      </Layout>
    );
  }
}
