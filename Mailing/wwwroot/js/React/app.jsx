import UserList from '../React/UserList.jsx'
import UserAccountForm from '../React/UserAccount.jsx'
import { getCurrentUsers} from '../React/Repository.jsx'

export default class App extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            users: [],
        };

        this.refreshEventHandler = this.refreshEventHandler.bind(this);
    }

    async refreshEventHandler() {
        const users = await getCurrentUsers();
        this.setState({ users });
    }

    async componentDidMount() {
        await this.refreshEventHandler();
    }

    render() {
        return (
            <div>
                <header className="masthead">
                    <div className="container px-4 px-lg-5 d-flex h-100 align-items-center justify-content-center">
                        <div className="d-flex justify-content-center">
                            <div className="text-center">
                                <h1 className="mx-auto my-0 text-uppercase">Mailing</h1>
                                <h2 className="text-white-50 mx-auto mt-2 mb-5">React Application with .Net API</h2>
                                <a className="btn btn-primary" href="#signup">Get Started</a>
                                <div className="row mt-5">
                                    {
                                        this.state.users.map((UserAccount, index) => (
                                            <UserList
                                                key={index}
                                                lastName={UserAccount.lastName}
                                                firstname={UserAccount.firstname}
                                                userEmail={UserAccount.userEmail}
                                            />
                                        ))
                                    }
                                </div>
                            </div>
                        </div>
                    </div>
                </header>
                <section className="signup-section" id="signup">
                    <div className="container px-4 px-lg-5">
                        <div className="row gx-4 gx-lg-5">
                            <div className="col-12 mx-auto text-center">
                                <UserAccountForm onSubmit={this.refreshEventHandler} />
                            </div>
                        </div>
                    </div>
                </section>
            </div>)
    }
}

ReactDOM.render(<App />, document.getElementById('app'));