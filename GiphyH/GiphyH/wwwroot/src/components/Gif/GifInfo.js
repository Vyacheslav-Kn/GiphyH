import React from "react"
import PropTypes from "prop-types"

import styles from "./styles/gif-info.css"
import GifDescription from "./GifDescription"
import GifImage from "./GifImage"

function GifInfo({imageUrl, title, publicationDate}) {
    return (
        <div className={styles.gifInfo}>
            <GifImage imageUrl={imageUrl} />
            <GifDescription title={title} publicationDate={publicationDate} />
        </div>
    )
}

GifInfo.propTypes = {
    imageUrl: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired,
    publicationDate: PropTypes.string.isRequired
}

export default GifInfo
