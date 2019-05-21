import React, {Component} from "react"
import PropTypes from "prop-types"

import SearchGifsButton from "../components/Search/SearchGifsButton"
import SearchPanel from "../components/Search/SearchPanel"

class SearchContainer extends Component {
    constructor(props) {
        super(props)

        const isSearchDisabled = true
        const searchPhrase = ""

        this.state = {isSearchDisabled, searchPhrase}
    }

    sendSearchRequest = () => {
        const {searchPhrase} = this.state
        const encodedPhrase = encodeURIComponent(searchPhrase)

        const {searchCallback} = this.props

        this.setState({isSearchDisabled: true, searchPhrase: ""})
        searchCallback(encodedPhrase)
    }

    updateSearchButton = (event) => {
        const searchPhrase = event.target.value
        const isSearchDisabled = !searchPhrase.length

        this.setState({isSearchDisabled, searchPhrase})
    }

    render() {
        const {searchPhrase} = this.state
        const {isSearchDisabled} = this.state

        return (
            <div>
                <SearchPanel changeCallback={this.updateSearchButton} searchPhrase={searchPhrase} />
                <SearchGifsButton searchCallback={this.sendSearchRequest} isSearchDisabled={isSearchDisabled} />
            </div>
        )
    }
}

SearchContainer.propTypes = {
    searchCallback: PropTypes.func.isRequired
}

export default SearchContainer
