import React from "react"
import PropTypes from "prop-types"

import styles from "./styles/gif-list.css"
import GifItem from "./GifItem"

function GifList({gifs}) {
    const gifList = gifs.map(gif => <GifItem gifId={gif.id} imageUrl={gif.imageUrl} key={gif.id}/>)

    return (
        <div className = {styles.loadedGifsContainer}>
            {gifList}
        </div>
    )
}

GifList.propTypes = {
    gifs: PropTypes.arrayOf(PropTypes.shape({
        id: PropTypes.string.isRequired,
        imageUrl: PropTypes.string.isRequired
    })).isRequired
}

export default GifList
