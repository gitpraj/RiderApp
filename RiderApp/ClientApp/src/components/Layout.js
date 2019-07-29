import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';
import Background from '../images/moped.jpg';

export class Layout extends Component {
  displayName = Layout.name

  render() {
      return (
        //<div class="">
        //    {this.props.children}
        //  </div>

          <div id="out">
              <div className="background" style={{ backgroundImage: "url(" + Background + ")" }}>
              </div>
              {this.props.children}
           </div>
    );
  }
}
