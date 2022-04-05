import React, { Component } from 'react';
import ReactTimeAgo from 'react-time-ago'
import {Link,
    useParams,
    useRouteMatch} from "react-router-dom";
import axios from "axios";

export class Home extends Component {
  static displayName = Home.name;

  constructor(props) {
    super(props);
    this.state = { posts: [], loading: true };
  }

  componentDidMount() {
    this.populatePosts();
  }

  render() {
    let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : Home.renderPosts(this.state.posts);

    return (
        <div className="row">
            <div className="col-12">
                <h1 id="tabelLabel" >Wall of fame</h1>
                <p>Fetching the greatest and latest from the social network </p>
                {contents}
            </div>
        </div>
    );
}

  static renderPosts(posts) {
    return (
        <React.Fragment>
                    {posts.map(post =>
                        <div className='card m-3'>
                            <img className='card-img-top' />
                            <div className='card-body'>
                                <h5 className='card-title'><Link to={`wall/${post.user.id}`}>{post.user.name}</Link></h5>
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
                </React.Fragment>
    );
}
    async populatePosts() {
        axios.get(`api/socialmedia/wall`)
            .then(result => {
                this.setState({posts: result.data, loading: false});
            })
            .catch( error => {
                console.log(error);
            });
    }
}
