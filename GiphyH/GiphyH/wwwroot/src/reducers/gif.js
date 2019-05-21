import {getInitialGifTypes} from "../action-types/gif"

const initialState = {
    beforeLoadedGif: {},
    gifId: 0,
    hasComeAfterSearching: false
}

function gifReducer(state = initialState, action) {
    const {payload} = action

    if(action.type === getInitialGifTypes.success) {
        const {beforeLoadedGif, gifId, hasComeAfterSearching} = payload

        return {
            beforeLoadedGif: {...beforeLoadedGif},
            gifId,
            hasComeAfterSearching
        }
    }

    return state
}

export default gifReducer
