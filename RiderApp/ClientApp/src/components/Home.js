import React, { Component } from 'react';
import Background from '../images/moped.jpg';
//import Background from 'https://lh3.googleusercontent.com/MOf9Kxxkj7GvyZlTZOnUzuYv0JAweEhlxJX6gslQvbvlhLK5_bSTK6duxY2xfbBsj43H=w300'
import './Home.css';

export class Home extends Component {
  displayName = Home.name

    constructor(props) {
        super(props);
        this.state = {
        }
        this.handleAddRiderSubmit = this.handleAddRiderSubmit.bind(this);
        this.handleViewRidersSubmit = this.handleViewRidersSubmit.bind(this);
    }

    handleAddRiderSubmit(e) {
        e.preventDefault();
        this.props.history.push("/addrider");
    }

    handleViewRidersSubmit(e) {
        e.preventDefault();
        this.props.history.push("/riders");
    }

  render() {
      return (
        <div className="bg-text">
              <div className="back">
                  <div className="button_base b07_3d_double_roll" onClick={this.handleAddRiderSubmit}>
                        <div>Add Rider</div>
                        <div>Add Rider</div>
                        <div>Add Rider</div>
                        <div>Add Rider</div>
                    </div>
                </div>
              <div className="back">
                <div className="button_base b07_3d_double_roll" onClick={this.handleViewRidersSubmit}>
                        <div>View Riders</div>
                        <div>View Riders</div>
                        <div>View Riders</div>
                        <div>View Riders</div>
                    </div>
                </div>
        </div>
    );
  }
}
