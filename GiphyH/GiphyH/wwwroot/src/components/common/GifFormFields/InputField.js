import React from "react"
import PropTypes from "prop-types"

import * as styles from "./styles/input-field.css"

const InputField = ({
    className,
    input,
    label,
    type,
    meta: {touched, error}
}) => (
    <div className={className}>
        <label>
            {label}
            <input {...input} type={type} />
        </label>
        {
            touched && (error && <p className={styles.errorMessage}>{error}</p>)
        }
    </div>
)

InputField.propTypes = {
    className: PropTypes.string,
    label: PropTypes.string,
    type: PropTypes.string.isRequired,
    meta: PropTypes.shape({
        touched: PropTypes.bool.isRequired,
        error: PropTypes.string
    }).isRequired,
    input: PropTypes.shape({
        name: PropTypes.string.isRequired
    })
}

export default InputField
