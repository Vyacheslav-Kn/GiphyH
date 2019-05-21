import React from "react"
import {Field, reduxForm} from "redux-form"
import PropTypes from "prop-types"

import * as fieldNames from "./constants/fieldNames"
import * as styles from "./styles/add-form.css"
import FileField from "./FileField"
import GifFormFields from "../common/GifFormFields/GifFormFields"

const AddForm = (props) => {
    const {handleSubmit} = props

    return (
        <form onSubmit={handleSubmit} className={styles.addForm} method="POST">
            <GifFormFields />
            <Field name={fieldNames.gif} component={FileField} type="file"/>
            <button type="submit">Add</button>
        </form>
    )
}

AddForm.propTypes = {
    onSubmit: PropTypes.func.isRequired,
    handleSubmit: PropTypes.func.isRequired
}

export default reduxForm({
    form: "AddForm"
})(AddForm)
