import React from "react"
import PropTypes from "prop-types"

function BackButton({moveBackCallback}) {
    return (
        <input type="submit" value="move back" onClick={moveBackCallback} />
    )
}

BackButton.propTypes = {
    moveBackCallback: PropTypes.func.isRequired
}

export default BackButton
