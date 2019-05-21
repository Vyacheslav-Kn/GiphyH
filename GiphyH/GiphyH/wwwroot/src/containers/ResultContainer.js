import React, {Component} from "react"
import PropTypes from "prop-types"
import {connect} from "react-redux"

import * as config from "../common/configuration"
import * as search from "../api/search"
import {chunkOfGifsCreators, searchCreators} from "../actions/search"
import ResultControl from "../components/Result/ResultControl"
import SearchContainer from "./SearchContainer"
import {getReducedGifs, getSearchProperties} from "../selectors/search"

class ResultContainer extends Component {
    getNextChunkOfGifs(searchProperties) {
        this.props.dispatchChunkOfGifsRequest({searchProperties})
    }

    getInitialChunkOfGifs(searchProperties) {
        this.props.dispatchSearchRequest({searchProperties})
    }

    updateResultControl = (searchPhrase) => {
        const searchProperties = {searchPhrase, offset: search.defaultOffset, limit: search.defaultLimit}
        const {history} = this.props

        history.replace(`/${config.urlToSearchMethod}${searchProperties.searchPhrase}`)
        this.getInitialChunkOfGifs(searchProperties)
    }

    loadNextChunkOfGifs = () => {
        const newSearchProperties = this.props.searchProperties
        newSearchProperties.offset += newSearchProperties.limit

        this.getNextChunkOfGifs(newSearchProperties)
    }

    getSearchPhraseFromUrl() {
        const {location} = this.props
        const params = new URLSearchParams(location.search)

        return params.get(config.searchPhraseQueryParam)
    }

    componentDidMount() {
        let {searchProperties} = this.props

        const currentSearchPhrase = this.getSearchPhraseFromUrl()
        const savedSearchPhrase = searchProperties.searchPhrase

        if(!savedSearchPhrase || (currentSearchPhrase !== savedSearchPhrase)) {
            searchProperties = {
                searchPhrase: currentSearchPhrase,
                offset: search.defaultOffset,
                limit: search.defaultLimit
            }

            this.getInitialChunkOfGifs(searchProperties)
        }
    }

    render() {
        const {gifs} = this.props

        return (
            <div>
                <SearchContainer searchCallback={this.updateResultControl} />
                {
                    gifs.length && <ResultControl gifs={gifs} loadCallback={this.loadNextChunkOfGifs} />
                }
            </div>
        )
    }
}

const mapState = state => ({
    gifs: getReducedGifs(state),
    searchProperties: getSearchProperties(state)
})

const mapDispatch = {
    dispatchChunkOfGifsRequest: chunkOfGifsCreators.request,
    dispatchSearchRequest: searchCreators.request
}

ResultContainer.propTypes = {
    dispatchChunkOfGifsRequest: PropTypes.func.isRequired,
    dispatchSearchRequest: PropTypes.func.isRequired,
    location: PropTypes.shape({
        search: PropTypes.string.isRequired
    }).isRequired,
    searchProperties: PropTypes.shape({
        searchPhrase: PropTypes.string
    }).isRequired,
    gifs: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.string.isRequired
        }).isRequired
    ).isRequired,
    history: PropTypes.shape({
        replace: PropTypes.func.isRequired
    }).isRequired
}

export default connect(mapState, mapDispatch)(ResultContainer)
