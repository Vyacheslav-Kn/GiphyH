import React from "react"
import PropTypes from "prop-types"

import styles from "./styles/search-gifs-button.css"

function SearchGifsButton({searchCallback, isSearchDisabled}) {
    return (
        <button
            className={styles.searchSubmit}
            onClick={searchCallback}
            disabled={isSearchDisabled}
        >
            search for gifs
        </button>
    )
}

SearchGifsButton.propTypes = {
    searchCallback: PropTypes.func.isRequired,
    isSearchDisabled: PropTypes.bool.isRequired
}

export default SearchGifsButton
