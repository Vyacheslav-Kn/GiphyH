import {getGifTypes, editGifTypes, deleteGifTypes} from "../action-types/editGif"

const initialState = {
    gif: {},
    editMessage: null,
    deleteMessage: null,
    hasComeAfterSearching: false
}

function editGifReducer(state = initialState, action) {
    const {payload} = action

    if(action.type === getGifTypes.success) {
        const {gif, hasComeAfterSearching} = payload
        const {editMessage, deleteMessage} = initialState

        return {
            gif: {...gif},
            editMessage,
            deleteMessage,
            hasComeAfterSearching
        }
    }

    const {hasComeAfterSearching} = state

    if(action.type === editGifTypes.success) {
        const {editMessage} = payload
        const {gif, deleteMessage} = initialState

        return {
            gif,
            editMessage,
            deleteMessage,
            hasComeAfterSearching
        }
    }

    if(action.type === deleteGifTypes.success) {
        const {deleteMessage} = payload
        const {gif, editMessage} = initialState

        return {
            gif,
            editMessage,
            deleteMessage,
            hasComeAfterSearching
        }
    }

    return state
}

export default editGifReducer
