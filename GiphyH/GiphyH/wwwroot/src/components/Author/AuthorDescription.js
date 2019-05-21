import React from "react"
import PropTypes from "prop-types"

function AuthorDescription({name}) {
    return (
        <div>
            {`Author info: ${name}`}
        </div>
    )
}

AuthorDescription.propTypes = {
    name: PropTypes.string.isRequired
}

export default AuthorDescription
