import {call, put, takeEvery} from "redux-saga/effects"

import {chunkOfGifsCreators, searchCreators} from "../actions/search"
import {searchGifTypes, getChunkOfGifsTypes} from "../action-types/search"
import {searchGifsByPhrase} from "../api/search"

function* getSearchResult(action) {
    const {searchProperties} = action.payload

    const gifs = yield call(searchGifsByPhrase, searchProperties)

    return {gifs, searchProperties}
}

function* addChunkOfGifs(action) {
    try {
        const result = yield call(getSearchResult, action)
        yield put(chunkOfGifsCreators.success(result))
    } catch(error) {
        yield put(chunkOfGifsCreators.fail({error}))
    }
}

export function* watchAddChunkOfGifs() {
    yield takeEvery(getChunkOfGifsTypes.request, addChunkOfGifs)
}

function* addInitialSearchData(action) {
    try {
        const result = yield call(getSearchResult, action)
        yield put(searchCreators.success(result))
    } catch(error) {
        yield put(searchCreators.fail({error}))
    }
}

export function* watchAddInitialSearchData() {
    yield takeEvery(searchGifTypes.request, addInitialSearchData)
}
