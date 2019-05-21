import React, {Component} from "react"
import PropTypes from "prop-types"

class FileField extends Component {
    handleChange = e => this.props.input.onChange(e.target.files[0])

    handleBlur = e => this.props.input.onBlur(e.target.files[0])

    render() {
        const {type} = this.props

        return (
            <input
                onChange={this.handleChange}
                onBlur={this.handleBlur}
                type={type}
            />
        )
    }
}

FileField.propTypes = {
    type: PropTypes.string.isRequired,
    input: PropTypes.shape({
        onChange: PropTypes.func.isRequired,
        onBlur: PropTypes.func.isRequired
    }).isRequired
}

export default FileField
