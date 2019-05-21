import {call, put, takeEvery} from "redux-saga/effects"

import {getInitialGifCreators} from "../actions/gif"
import {getInitialGifTypes} from "../action-types/gif"
import {getGifById} from "../api/search"

const {success, fail} = getInitialGifCreators

function* addInitialGifData(action) {
    const {gifId, hasComeAfterSearching} = action.payload

    try {
        const gif = yield call(getGifById, gifId)
        yield put(success({beforeLoadedGif: gif, gifId, hasComeAfterSearching}))
    } catch(error) {
        yield put(fail({error}))
    }
}

export function* watchAddInitialGifData() {
    yield takeEvery(getInitialGifTypes.request, addInitialGifData)
}
