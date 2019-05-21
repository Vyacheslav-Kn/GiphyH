import React from "react"
import PropTypes from "prop-types"

function AuthorAvatar({avatarUrl}) {
    return (
        <img src={avatarUrl} />
    )
}

AuthorAvatar.propTypes = {
    avatarUrl: PropTypes.string.isRequired
}

export default AuthorAvatar
