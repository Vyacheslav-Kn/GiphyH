import React, {Component} from "react"
import PropTypes from "prop-types"
import {connect} from "react-redux"

import * as config from "../common/configuration"
import {getInitialGifCreators} from "../actions/gif"
import AuthorInfo from "../components/Author/AuthorInfo"
import BackButton from "../components/BackButton"
import GifInfo from "../components/Gif/GifInfo"
import {getGifId, getHasComeAfterSearching, getReducedGif} from "../selectors/gif"

class GifContainer extends Component {
    addInitialGifData(gifId, hasComeAfterSearching) {
        this.props.dispatchRequest({gifId, hasComeAfterSearching})
    }

    moveBack = () => {
        const {hasComeAfterSearching} = this.props
        const {history} = this.props

        if(hasComeAfterSearching) {
            history.goBack()
            return
        }

        history.push("/")
    }

    componentDidMount() {
        const {beforeLoadedGif} = this.props

        const currentGifId = this.props.match.params[config.gifIdQueryParam]
        const locationState = this.props.location.state
        const hasComeAfterSearching = locationState ? locationState.hasComeAfterSearching : false

        if(!beforeLoadedGif.id || (currentGifId !== beforeLoadedGif.id)) {
            this.addInitialGifData(currentGifId, hasComeAfterSearching)
        }
    }

    render() {
        const gif = this.props.beforeLoadedGif

        if(!gif.id) {
            return null
        }

        const {author} = gif

        return (
            <div>
                <GifInfo imageUrl={gif.imageUrl} title={gif.title} publicationDate={gif.publicationDate} />
                {
                    author && <AuthorInfo avatarUrl={author.avatarUrl} name={author.name} />
                }
                <BackButton moveBackCallback={this.moveBack} />
            </div>
        )
    }
}

const mapState = state => ({
    beforeLoadedGif: getReducedGif(state),
    gifId: getGifId(state),
    hasComeAfterSearching: getHasComeAfterSearching(state)
})

const mapDispatch = {
    dispatchRequest: getInitialGifCreators.request
}

GifContainer.propTypes = {
    dispatchRequest: PropTypes.func.isRequired,
    match: PropTypes.shape({
        params: PropTypes.shape({
            gifId: PropTypes.string.isRequired
        })
    }).isRequired,
    location: PropTypes.shape({
        state: PropTypes.shape({
            hasComeAfterSearching: PropTypes.bool.isRequired
        })
    }).isRequired,
    beforeLoadedGif: PropTypes.shape({
        id: PropTypes.string
    }).isRequired,
    hasComeAfterSearching: PropTypes.bool.isRequired,
    history: PropTypes.shape({
        goBack: PropTypes.func.isRequired
    }).isRequired
}

export default connect(mapState, mapDispatch)(GifContainer)
