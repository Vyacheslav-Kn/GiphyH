import React from "react"
import PropTypes from "prop-types"

import styles from "./styles/result-control.css"
import GifList from "./GifList"
import LoadGifsButton from "./LoadGifsButton"

function ResultControl({gifs, loadCallback}) {
    return (
        <div className={styles.resultControl}>
            <GifList gifs={gifs} />
            <LoadGifsButton loadCallback={loadCallback} />
        </div>
    )
}

ResultControl.propTypes = {
    gifs: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.string.isRequired,
        imageUrl: PropTypes.string.isRequired
    })).isRequired,
    loadCallback: PropTypes.func.isRequired
}

export default ResultControl
