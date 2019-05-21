import React from "react"
import PropTypes from "prop-types"

function SearchPanel({changeCallback, searchPhrase}) {
    return (
        <input type="text" onChange={changeCallback} value={searchPhrase} />
    )
}

SearchPanel.propTypes = {
    searchPhrase: PropTypes.string.isRequired,
    changeCallback: PropTypes.func.isRequired
}

export default SearchPanel
