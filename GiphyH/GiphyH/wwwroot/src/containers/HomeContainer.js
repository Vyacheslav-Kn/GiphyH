import React, {Component} from "react"
import PropTypes from "prop-types"
import {Link} from "react-router-dom"

import * as config from "../common/configuration"
import * as styles from "../components/Home/styles/index.css"
import SearchContainer from "./SearchContainer"

class HomeContainer extends Component {
    redirectToSearchPage = (searchPhrase) => {
        const {history} = this.props
        history.push(`/${config.urlToSearchMethod}${searchPhrase}`)
    }

    render() {
        return (
            <div>
                <SearchContainer searchCallback={this.redirectToSearchPage} />
                <Link to={`${config.urlToAddMethod}`} className={styles.loadLink}>Load gif</Link>
            </div>
        )
    }
}

HomeContainer.propTypes = {
    history: PropTypes.shape({
        push: PropTypes.func.isRequired
    }).isRequired
}

export default HomeContainer
