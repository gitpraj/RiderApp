import React, { Component } from 'react';
import { Rider } from './Rider';

export class Riders extends Component {
    displayName = Riders.name

    constructor(props) {
        super(props);
        this.state = { data: [] };

        this.handleBackButton = this.handleBackButton.bind(this);
        this.updateRiders = this.updateRiders.bind(this);
    }

    componentWillMount() {

        fetch('api/Rider/GetRiders', {
            method: 'GET'
        }).then((response) => response.json())
            .then((responseJson) => {
                console.log("success: " + JSON.stringify(responseJson))
                if (responseJson != null) {
                    this.setState({ data: responseJson })
                } else {
                    this.setState({ errors: "Credentials seem to be wrong. Please try again or first register with us" })
                }
            })
    }

    /**
     * This function is callback from the child component Rider
     * */
    updateRiders() {
        this.componentWillMount();
    }

    handleBackButton(e) {
        this.props.history.push("/");
    }

    render() {
        const { data } = this.state
        const { history } = this.props;

        return (
            <div className="bg-text-left">
                <div className="row">
                    <div className="back-button">
                        <a className="next round" onClick={this.handleBackButton}>&#8249;</a>
                    </div>
                </div>
                {
                    data.map(rider =>
                        //<Blog key={blg.id} blogSummary={blg} />)
                        <Rider key={rider.riderid} history={history} riderInfo={rider} updateRiders={this.updateRiders} />)
                }
                    
                </div>
        );
    }
}
