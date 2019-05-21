import {call, put, takeEvery} from "redux-saga/effects"

import {deleteGifCreators, editGifCreators, getGifCreators} from "../actions/editGif"
import * as messages from "../messages"
import {deleteGifTypes, editGifTypes, getGifTypes} from "../action-types/editGif"
import {getGifById} from "../api/search"

function* getGif(action) {
    const {gifId, hasComeAfterSearching} = action.payload

    try {
        const gif = yield call(getGifById, gifId)
        yield put(getGifCreators.success({gif, hasComeAfterSearching}))
    } catch(error) {
        yield put(getGifCreators.fail({error}))
    }
}

export function* watchGetGif() {
    yield takeEvery(getGifTypes.request, getGif)
}

function* editGif(action) {
    const {gif} = action.payload

    try {
        setTimeout(console.log("Edit request sending..."), 1000)
        yield put(editGifCreators.success({editMessage: messages.editSucceed}))
    } catch(error) {
        yield put(editGifCreators.fail({error}))
    }
}

export function* watchEditGif() {
    yield takeEvery(editGifTypes.request, editGif)
}

function* deleteGif(action) {
    const {gifId} = action.payload

    try {
        setTimeout(console.log("Delete request sending..."), 1000)
        yield put(deleteGifCreators.success({deleteMessage: messages.deleteSucceed}))
    } catch(error) {
        yield put(deleteGifCreators.fail({error}))
    }
}

export function* watchDeleteGif() {
    yield takeEvery(deleteGifTypes.request, deleteGif)
}
