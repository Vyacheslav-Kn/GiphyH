import React, {Component} from "react"
import PropTypes from "prop-types"
import {connect} from "react-redux"

import {getAddCreators} from "../actions/addGif"
import {getAddedGif, getFileName, getTitle} from "../selectors/addGif"
import AddForm from "../components/AddGif/AddForm"

class AddGifContainer extends Component {
    addGif = ({gif, title}) => this.props.dispatchAddRequest({gif, title})

    render() {
        const {name} = this.props
        let message

        if(name) {
            message = <span>Gif was loaded! File name: {name}</span>
        }

        return (
            <div>
                {message}
                <AddForm onSubmit = {this.addGif} />
            </div>
        )
    }
}

const mapState = state => ({
    gif: getAddedGif(state),
    title: getTitle(state),
    name: getFileName(state)
})

const mapDispatch = {
    dispatchAddRequest: getAddCreators.request
}

AddGifContainer.propTypes = {
    name: PropTypes.string,
    dispatchAddRequest: PropTypes.func.isRequired
}

export default connect(mapState, mapDispatch)(AddGifContainer)
