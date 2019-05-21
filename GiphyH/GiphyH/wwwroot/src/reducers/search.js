import {searchGifTypes, getChunkOfGifsTypes} from "../action-types/search"

const initialState = {
    gifs: [],
    searchProperties: {}
}

function searchReducer(state = initialState, action) {
    const {payload} = action

    if(action.type === searchGifTypes.success) {
        const gifs = payload.gifs || state.gifs
        const searchProperties = payload.searchProperties || state.searchProperties

        return {
            gifs: [...gifs],
            searchProperties: {...searchProperties}
        }
    }

    if(action.type === getChunkOfGifsTypes.success) {
        const searchProperties = {...payload.searchProperties}

        return {
            gifs: state.gifs.concat(payload.gifs),
            searchProperties
        }
    }

    return state
}

export default searchReducer
