import React, { Component } from 'react';
import { Col } from 'react-bootstrap';
import './Rider.css';

export class Rider extends Component {
    displayName = Rider.name

    constructor(props) {
        super(props);
        this.state = { data: [], rider:'' };

        this.handleUpdateRiderSubmit = this.handleUpdateRiderSubmit.bind(this);
        this.handleDeleteRiderSubmit = this.handleDeleteRiderSubmit.bind(this);
    }

    handleUpdateRiderSubmit(e) {
        e.preventDefault();
        //this.props.history.push("/updaterider");
        this.props.history.push({
            pathname: '/updaterider',
            riderInfo: { rider: this.state.rider }
        })
    }

    handleDeleteRiderSubmit(e) {
        e.preventDefault();
        const { riderid } = this.props.riderInfo;

        fetch('api/Rider/Delete/' + riderid, {
            method: 'DELETE'
        }).then((response) => response.json())
            .then((responseJson) => {
                console.log("success: " + responseJson)
                if (responseJson != -1) {
                    //this.setState({
                    //    message: "Rider Updated Successfully",
                    //})
                    console.log("deleted rider")
                    this.props.updateRiders();

                } else {
                    //this.setState({ message: "Rider Email to be unique" })
                }
            })
    }

    componentWillMount() {
        fetch('api/Rider/Details/' + this.props.riderInfo.riderid, {
            method: 'GET'
        }).then((response) => response.json())
            .then((responseJson) => {
                console.log("success: " + JSON.stringify(responseJson))
                if (responseJson != null) {
                    //this.setState({ data: responseJson })
                    this.setState({
                        rider: responseJson
                    })
                } else {
                    //this.setState({ errors: "Credentials seem to be wrong. Please try again or first register with us" })
                }
            })
        
    }

    render() {

        const { riderInfo } = this.props;
        const firstname = this.state.rider.firstName;
        const lastname = this.state.rider.lastName;

        const riderid = riderInfo.riderid;
        const avgReviewScore = riderInfo.avgReviewScore;
        const bestReviewScore = riderInfo.bestReviewScore;
        const bestReviewComment = riderInfo.bestReviewComment;
        //console.log(blogentry)

        return (
            <div className="" id={riderid}>
                <h3>{firstname} {lastname}</h3>
                <h4>Avg Review Score: {avgReviewScore}</h4>
                <h4>Best Review Score: {bestReviewScore}</h4>
                <h4>Best Review Comment: {bestReviewComment}</h4>
                
                <div className="btn-group">
                    <button type="submit" className="btn btn-success" id="UpdateButton" onClick={this.handleUpdateRiderSubmit}>
                        Update Rider
                    </button>
                    <button type="submit" className="btn btn-danger" id="DeleteButton" onClick={this.handleDeleteRiderSubmit}>
                        Delete Rider
                    </button>
                </div>

                <hr className="underline-red" />
            </div>
        );
    }
}
