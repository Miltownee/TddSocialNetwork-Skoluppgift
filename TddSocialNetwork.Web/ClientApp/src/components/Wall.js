import React, {Component} from 'react';
import ReactTimeAgo from 'react-time-ago'
import axios from 'axios';

export class Wall extends Component {
    static displayName = Wall.name;

    constructor(props) {
        super(props);

        this.state = {
            user: [],
            loading: true,
            postValue: 'Post a message to the wall',
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleChange(event) {
        this.setState({postValue: event.target.value});
    }

    handleSubmit(event) {
        this.sendPost(this.state.postValue, this.state.user.id)
        event.preventDefault();
    }

    componentDidMount() {
        const {id} = this.props.match.params;
        this.populateuser(id);
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <React.Fragment>
                <h1 id="tabelLabel">Wall of {this.state.user.name}</h1>
                <form onSubmit={this.handleSubmit}>
                    <div className="form-group">
                    <textarea
                        value={this.state.postValue}
                        onChange={this.handleChange}
                        className='form-control'/>
                        <button type="submit" className="btn btn-primary">Send post</button>
                    </div>
                </form>
                {this.state.user.timelinePosts.map(post =>
                    <div className='card m-3'>
                        <img className='card-img-top'/>
                        <div className='card-body'>
                            <p className='card-text'>{post.message}</p>
                            <p className="card-text">
                                <small className="text-muted">
                                    <ReactTimeAgo date={post.created} locale="en-US" timeStyle="twitter"/>
                                </small>
                            </p>
                        </div>
                    </div>
                )}
                <div className="clearfix"></div>
            </React.Fragment>;

        return (
            <div className="row">
                <div className="col-12">
                    {contents}
                </div>
            </div>
        );
    }


    async populateuser(id) {
        axios.get(`api/socialmedia/wall/${id}`)
            .then(result => {
                this.setState({user: result.data, loading: false});
            })
            .catch( error => {
                console.log(error);
            });
    }

    async sendPost(message, id) {
        const data = {message: message, id: id}
        axios.post('api/socialmedia/post/',data)
            .then( result => {
                console.log(result);
                this.populateuser(id);
            })
            .catch( error => {
                console.log(error);
            });
    }
}
