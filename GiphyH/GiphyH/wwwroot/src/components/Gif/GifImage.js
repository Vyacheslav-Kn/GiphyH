import React from "react"
import PropTypes from "prop-types"

function GifImage({imageUrl}) {
    return (
        <img src={imageUrl} />
    )
}

GifImage.propTypes = {
    imageUrl: PropTypes.string.isRequired
}

export default GifImage
