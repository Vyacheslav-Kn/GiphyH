import {Route, Switch} from "react-router-dom"
import {ConnectedRouter} from "connected-react-router"
import React, {Component} from "react"
import PropTypes from "prop-types"
import {hot} from "react-hot-loader"

import * as config from "../common/configuration"
import GifContainer from "../containers/GifContainer"
import HomeContainer from "../containers/HomeContainer"
import ResultContainer from "../containers/ResultContainer"
import EditGifContainer from "../containers/EditGifContainer"
import AddGifContainer from "../containers/AddGifContainer"

class App extends Component {
    render() {
        const {history} = this.props

        return (
            <ConnectedRouter history={history}>
                <Switch>
                    <Route exact path="/" component={HomeContainer} />
                    <Route path={`/${config.routeToSearchMethod}`} component={ResultContainer} />
                    <Route exact path={`/${config.urlToGifMethod}:${config.gifIdQueryParam}`} component={GifContainer} />
                    <Route exact path={`/${config.urlToEditMethod}:${config.gifIdQueryParam}`} component={EditGifContainer} />
                    <Route exact path={`/${config.urlToAddMethod}`} component={AddGifContainer} />
                </Switch>
            </ConnectedRouter>
        )
    }
}

App.propTypes = {
    history: PropTypes.shape({
        location: PropTypes.shape({
            pathname: PropTypes.string
        })
    })
}

export default hot(module)(App)
