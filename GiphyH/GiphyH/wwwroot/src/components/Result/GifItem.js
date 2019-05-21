import {Link} from "react-router-dom"
import React from "react"
import PropTypes from "prop-types"

import {urlToEditMethod, urlToGifMethod} from "root/src/common/configuration"
import styles from "./styles/gif-item.css"

function GifItem({gifId, imageUrl}) {
    const getLocation = url => ({
        pathname: `/${url}${gifId}`,
        state: {
            hasComeAfterSearching: true
        }
    })

    return (
        <div className={styles.gifItem}>
            <Link to={getLocation(urlToGifMethod)} className={styles.gifLink}>
                <img src={imageUrl} />
            </Link>
            <p>
                <Link to={getLocation(urlToEditMethod)} className={styles.editLink}>Edit</Link>
            </p>
        </div>
    )
}

GifItem.propTypes = {
    gifId: PropTypes.string.isRequired,
    imageUrl: PropTypes.string.isRequired
}

export default GifItem
