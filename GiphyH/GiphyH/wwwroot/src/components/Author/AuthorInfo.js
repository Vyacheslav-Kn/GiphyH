import React from "react"
import PropTypes from "prop-types"

import * as styles from "./styles/author-info.css"
import AuthorAvatar from "./AuthorAvatar"
import AuthorDescription from "./AuthorDescription"

function AuthorInfo({avatarUrl, name}) {
    return (
        <div className={styles.authorInfo}>
            <AuthorAvatar avatarUrl={avatarUrl} />
            <AuthorDescription name={name} />
        </div>
    )
}

AuthorInfo.propTypes = {
    avatarUrl: PropTypes.string.isRequired,
    name: PropTypes.string.isRequired
}

export default AuthorInfo
