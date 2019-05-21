import React from "react"
import PropTypes from "prop-types"

function MessageDialog({message}) {
    return (
        <span>{message}</span>
    )
}

MessageDialog.propTypes = {
    message: PropTypes.string.isRequired
}

export default MessageDialog
