import { postNewUser } from '../React/Repository.jsx'

export default class UserAccountForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            activeButton: false,
            lastName: "Gomez",
            firstName: "Hector",
            emailAddress: "papelote@gmail.co",
        };

        this.updateInputLastName = this.updateInputLastName.bind(this);
        this.updateInputFirstName = this.updateInputFirstName.bind(this);
        this.updateInputEmail = this.updateInputEmail.bind(this);
        this.submitHandler = this.submitHandler.bind(this);
    }

    isReady() {

        const isLastNamePresent = this.state.lastName.length > 0;
        const isFirstNamePresent = this.state.firstName.length > 0;
        const isEmailAddressPresent = this.state.emailAddress.length > 0;

        if (isLastNamePresent && isFirstNamePresent && isEmailAddressPresent)
            this.setState({ activeButton: true });
    }

    submitHandler(e) {
        e.preventDefault();
        const lastName = this.state.lastName;
        const firstName = this.state.firstName;
        const emailAddress = this.state.emailAddress;


        postNewUser(lastName, firstName, emailAddress);

        Swal.fire("You're now subscribed").then(() => {
            this.setState({
                lastName: "second user",
                firstName: "second user",
                emailAddress: "second@user.co",
                activeButton: false
            });
            document.documentElement.scrollTop = 0;
            this.props.onSubmit();
        });


    }

    updateInputLastName(evt) {
        this.setState({ lastName: evt.target.value }, () => {
            this.isReady();
        });
    }

    updateInputFirstName(evt) {
        this.setState({ firstName: evt.target.value }, () => {
            this.isReady();
        });
    }

    updateInputEmail(evt) {
        console.log(this.state.emailAddress);
        console.log(evt.target.value);
        this.setState({ emailAddress: evt.target.value }, () => {
            this.isReady();
        });
        console.log(this.state.emailAddress);
    }

    render() {
        return (
            <div>
                <form className="form-signup" onSubmit={this.submitHandler}>
                    <i className="far fa-paper-plane fa-2x mb-2 text-white"></i>
                    <h2 className="text-white mb-5">Subscribe to receive updates!</h2>
                    <div className="row input-group-newsletter">
                        <div className="col-3 mb-5">
                            <input className="form-control"
                                id="lastName"
                                type="text"
                                placeholder="Enter your Last name..."
                                aria-label="Enter your Last name..."
                                data-sb-validations="required"
                                value={this.state.lastName}
                                onChange={this.updateInputLastName} />
                            <div className="invalid-feedback mt-2" data-sb-feedback="lastName:required">Last Name is required</div>
                        </div>

                        <div className="col-3 mb-5">
                            <input className="form-control"
                                id="firstName"
                                type="text"
                                placeholder="Enter your First name..."
                                aria-label="Enter your First name..."
                                data-sb-validations="required"
                                value={this.state.firstName}
                                onChange={this.updateInputFirstName} />
                            <div className="invalid-feedback mt-2" data-sb-feedback="firstName:required">First Name is required.</div>
                        </div>
                        <div className="col-6 mb-5">
                            <input className="form-control" id="emailAddress"
                                type="email" placeholder="Enter email address..." aria-label="Enter email address..."
                                data-sb-validations="required,email"
                                value={this.state.emailAddress}
                                onChange={this.updateInputEmail} />
                            <div className="invalid-feedback mt-2" data-sb-feedback="emailAddress:required">An email is required.</div>
                            <div className="invalid-feedback mt-2" data-sb-feedback="emailAddress:email">Email is not valid.</div>
                        </div>
                        <div className="row d-flex justify-content-center mt-5">
                            <div className="col-auto">
                                <button className={`btn btn-primary ${this.state.activeButton ? "" : "disabled"}`} id="submitButton" type="submit">Notify Me!</button>
                            </div>
                        </div>
                    </div>

                    <div className="d-none" id="submitSuccessMessage">
                        <div className="text-center mb-3 mt-2 text-white">
                            <div className="fw-bolder">Form submission successful!</div>
                        </div>
                    </div>
                    <div className="d-none" id="submitErrorMessage"><div className="text-center text-danger mb-3 mt-2">Error sending message!</div></div>
                </form>
            </div>
        );
    }
}