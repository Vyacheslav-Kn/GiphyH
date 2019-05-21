import React, {Component} from "react"
import PropTypes from "prop-types"
import {connect} from "react-redux"

import * as config from "../common/configuration"
import {deleteGifCreators, editGifCreators, getGifCreators} from "../actions/editGif"
import * as selectors from "../selectors/editGif"
import EditForm from "../components/EditGif/EditForm"
import MessageDialog from "../components/EditGif/MessageDialog"
import BackButton from "../components/BackButton"
import ModalDialog from "../components/EditGif/ModalDialog"

class EditGifContainer extends Component {
    getGif = (gifId, hasComeAfterSearching) => this.props.dispatchGetRequest({gifId, hasComeAfterSearching})

    editGif = gif => this.props.dispatchEditRequest({gif})

    deleteGif = () => this.props.dispatchDeleteRequest({gifId: this.getCurrentGifId()})

    getCurrentGifId = () => this.props.match.params[config.gifIdQueryParam]

    componentDidMount() {
        const {gif} = this.props

        const currentGifId = this.getCurrentGifId()
        const locationState = this.props.location.state
        const hasComeAfterSearching = locationState ? locationState.hasComeAfterSearching : false

        if(!gif.id || (currentGifId !== gif.id)) {
            this.getGif(currentGifId, hasComeAfterSearching)
        }
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

    render() {
        const {gif, editMessage, deleteMessage} = this.props
        const message = editMessage || deleteMessage

        if(!gif.id && !message) {
            return null
        }

        if(message) {
            return (
                <div>
                    <MessageDialog message={message} />
                    <BackButton moveBackCallback={this.moveBack} />
                </div>
            )
        }

        return (
            <div>
                <ModalDialog deleteCallback = {this.deleteGif} />
                <EditForm onSubmit = {this.editGif} initialValues={gif} />
            </div>
        )
    }
}

const mapState = state => ({
    gif: selectors.getReducedGifForEdition(state),
    editMessage: selectors.getEditMessage(state),
    deleteMessage: selectors.getDeleteMessage(state),
    hasComeAfterSearching: selectors.getHasComeAfterSearching(state)
})

const mapDispatch = {
    dispatchGetRequest: getGifCreators.request,
    dispatchEditRequest: editGifCreators.request,
    dispatchDeleteRequest: deleteGifCreators.request
}

EditGifContainer.propTypes = {
    dispatchGetRequest: PropTypes.func.isRequired,
    dispatchEditRequest: PropTypes.func.isRequired,
    dispatchDeleteRequest: PropTypes.func.isRequired,
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
    gif: PropTypes.shape({
        id: PropTypes.string
    }).isRequired,
    hasComeAfterSearching: PropTypes.bool.isRequired,
    editMessage: PropTypes.string,
    deleteMessage: PropTypes.string,
    history: PropTypes.shape({
        goBack: PropTypes.func.isRequired
    }).isRequired
}

export default connect(mapState, mapDispatch)(EditGifContainer)
