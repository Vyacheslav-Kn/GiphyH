import {put, takeEvery} from "redux-saga/effects"

import {getAddCreators} from "../actions/addGif"
import {addGifTypes} from "../action-types/addGif"

function* addGif(action) {
    const {gif, title} = action.payload

    try {
        setTimeout(console.log("Load request sending..."), 1000)
        yield put(getAddCreators.success({gif, title}))
    } catch(error) {
        yield put(getAddCreators.fail({error}))
    }
}

export function* watchAddGif() {
    yield takeEvery(addGifTypes.request, addGif)
}
