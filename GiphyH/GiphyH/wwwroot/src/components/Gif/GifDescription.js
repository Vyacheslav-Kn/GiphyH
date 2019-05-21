import React from "react"
import PropTypes from "prop-types"

function GifDescription({title, publicationDate}) {
    return (
        <div>
            {`Gif info: ${title} ${publicationDate}`}
        </div>
    )
}

GifDescription.propTypes = {
    title: PropTypes.string.isRequired,
    publicationDate: PropTypes.string.isRequired
}

export default GifDescription
