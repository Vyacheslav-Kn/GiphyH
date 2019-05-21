import React, {Component} from "react"
import Modal from "react-modal"
import PropTypes from "prop-types"

import DeleteButton from "./DeleteButton"
import * as styles from "./styles/modal-dialog.css"

class ModalDialog extends Component {
    constructor(props, context) {
        super(props, context)

        this.state = {
            isOpen: false
        }
    }

    close = () => this.setState({isOpen: false})

    show = () => this.setState({isOpen: true})

    deleteGif = () => {
        this.close()
        this.props.deleteCallback()
    }

    render() {
        return (
            <div>
                <button onClick={this.show}>Delete</button>

                <Modal
                    isOpen={this.state.isOpen}
                    onRequestClose={this.close}
                    className={styles.modal}
                    ariaHideApp={false}
                >
                    <div className={styles.modalContent}>
                        <p className={styles.modalMessage}>Are you shure you want to delete gif ?</p>
                        <button onClick={this.close} className={styles.cancelButton}>cancel</button>
                        <DeleteButton deleteCallback={this.deleteGif} />
                    </div>
                </Modal>
            </div>
        )
    }
}

ModalDialog.propTypes = {
    deleteCallback: PropTypes.func.isRequired
}

export default ModalDialog
