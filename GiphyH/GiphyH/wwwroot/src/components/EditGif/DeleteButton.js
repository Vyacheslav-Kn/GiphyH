import React from "react"
import PropTypes from "prop-types"

import * as styles from "./styles/modal-dialog.css"

function DeleteButton({deleteCallback}) {
    return (
        <button onClick={deleteCallback} className={styles.agreeButton}>delete gif</button>
    )
}

DeleteButton.propTypes = {
    deleteCallback: PropTypes.func.isRequired
}

export default DeleteButton
