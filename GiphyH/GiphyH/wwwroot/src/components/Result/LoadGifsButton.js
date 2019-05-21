import React from "react"
import PropTypes from "prop-types"

function LoadGifsButton({loadCallback}) {
    return (
        <button onClick={loadCallback}>load gifs</button>
    )
}

LoadGifsButton.propTypes = {
    loadCallback: PropTypes.func.isRequired
}

export default LoadGifsButton
