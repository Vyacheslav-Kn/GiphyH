import React from "react"
import {Field} from "redux-form"

import * as validate from "root/src/validation"
import InputField from "./InputField"
import * as fieldNames from "./constants/fieldNames"

const checkIfEmpty = validate.minLength(1)

function GifFormFields() {
    return (
        <div>
            <Field
                name={fieldNames.title}
                type="text"
                component={InputField}
                label="Title"
                validate={checkIfEmpty}
            />
        </div>
    )
}

export default GifFormFields
