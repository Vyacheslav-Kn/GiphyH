import React from "react"
import {Field, reduxForm} from "redux-form"
import PropTypes from "prop-types"

import * as fieldNames from "./constants/fieldNames"
import * as styles from "./styles/edit-form.css"
import InputField from "../common/GifFormFields/InputField"
import GifFormFields from "../common/GifFormFields/GifFormFields"

const EditForm = (props) => {
    const {handleSubmit} = props

    return (
        <form onSubmit={handleSubmit} className={styles.editForm} method="POST">
            <Field
                name={fieldNames.id}
                type="hidden"
                component={InputField}
            />
            <GifFormFields />
            <button type="submit">Submit</button>
        </form>
    )
}

EditForm.propTypes = {
    onSubmit: PropTypes.func.isRequired,
    handleSubmit: PropTypes.func.isRequired,
    initialValues: PropTypes.shape({
        id: PropTypes.string.isRequired,
        title: PropTypes.string.isRequired
    })
}

export default reduxForm({
    form: "EditForm",
    touchOnBlur: false,
    touchOnChange: true
})(EditForm)
