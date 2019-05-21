import {addGifTypes} from "../action-types/addGif"

const initialState = {
    gif: null,
    title: null,
    name: null
}

function addGifReducer(state = initialState, action) {
    const {payload} = action

    if(action.type === addGifTypes.success) {
        const {gif, title} = payload
        const {name} = gif

        return {
            gif: {...gif},
            name,
            title
        }
    }

    return state
}

export default addGifReducer
