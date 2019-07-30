import React, { Component } from 'react';
import './Home.css';
import './AddRider.css';

export class AddRider extends Component {
    displayName = AddRider.name

    constructor(props) {
        super(props);
        this.state = {
            firstname: '',
            lastname: '',
            phonenum: '',
            email: '',
            message: ''
        }
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleBackButton = this.handleBackButton.bind(this);
    }

    /**
     * This function hadles submit on the form and calls API to create new rider.
     * @param {any} e
     */
    handleSubmit(e) {
        e.preventDefault();

        
        var formData = new FormData(e.target);
        formData.append('FirstName', this.state.firstname);
        formData.append('LastName', this.state.lastname);
        formData.append('Email', this.state.email);
        formData.append('PhoneNumber', this.state.phonenum);
        console.log(formData)

        fetch('api/Rider/Create', {
            method: 'POST',
            body: formData,
        }).then((response) => response.json())
            .then((responseJson) => {
                console.log("success: " + responseJson)
                if (responseJson != -1) {
                    this.setState({
                        message: "Rider added Successfully",
                        firstname: "",
                        lastname: "",
                        phonenum: "",
                        email: "",
                    })

                } else {
                    this.setState({ message: "Rider Email to be unique" })
                }
            })
    }

    /**
     * This function handled the back button. Goes to home page
     * @param {any} e
     */
    handleBackButton(e) {
        this.props.history.push("/");
    }

    validateEmail(email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }

    validatePhone(phone) {
        var re = /^\(?(?:\+?61|0)([4]{1})[0-9]{8,8}$/;
        return re.test(phone);
    }
    /**
     * validate() - validation on the form.
     * @param {any} firstname
     * @param {any} lastname
     * @param {any} phonenum
     * @param {any} email
     */
    validate(firstname, lastname, phonenum, email) {
        // true means invalid, so our conditions got reversed
        const isFine = firstname.length > 0 && lastname.length > 0 && this.validateEmail(email) > 0 && this.validatePhone(phonenum) > 0;
        return isFine;
    }

    render() {

        var isFine = this.validate(this.state.firstname, this.state.lastname, this.state.phonenum,
            this.state.email)
        const message = this.state.message;

        return (
            <div className="bg-text">
                <form onSubmit={this.handleSubmit}>
                    <div className="">
                        
                        <div className="row">
                            <div className="col-lg-3 back-button">
                                <a className="next round" onClick={this.handleBackButton}>&#8249;</a>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col-lg-3">
                                <div className="form-group">
                                    <input value=""
                                        name="subject"
                                        type="text"
                                        className="form-control input-w-60"
                                        id="firstname"
                                        placeholder="First Name"
                                        onChange={e => this.setState({ firstname: e.target.value })}
                                        value={this.state.firstname}
                                        required />
                                    <span className="help-block" id=""></span>
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col-lg-3">
                                <div className="form-group">
                                    <input value=""
                                        name="subject"
                                        type="text"
                                        className="form-control input-w-60"
                                        id="lastname"
                                        placeholder="Last Name"
                                        onChange={e => this.setState({ lastname: e.target.value })}
                                        value={this.state.lastname}
                                        required />
                                    <span className="help-block" id=""></span>
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col-lg-3">
                                <div className="form-group">
                                    <input value=""
                                        name="subject"
                                        type="text"
                                        className="form-control input-w-60"
                                        id="phonenum"
                                        placeholder="Phone Number"
                                        onChange={e => this.setState({ phonenum: e.target.value })}
                                        value={this.state.phonenum}
                                        required />
                                    <span className="help-block" id=""></span>
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col-lg-3">
                                <div className="form-group">
                                    <input value=""
                                        name="subject"
                                        type="text"
                                        className="form-control input-w-60"
                                        id="email"
                                        placeholder="Email"
                                        onChange={e => this.setState({ email: e.target.value })}
                                        value={this.state.email}
                                        required />
                                    <span className="help-block" id=""></span>
                                </div>
                            </div>
                        </div>

                        <div className="row">
                            <div className="col-lg-3">
                                <button type="submit" disabled={!isFine} className="btn btn-success" id="AddButton">Add Rider</button>
                            </div>
                        </div>

                        

                        <div className="row">
                            <div className="col-lg-3">
                                <span><h3 className="" style={{ color: "red" }}><b>{message}</b></h3></span>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        );
    }
}
