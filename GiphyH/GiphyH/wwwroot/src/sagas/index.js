import {all} from "redux-saga/effects"

import {watchAddChunkOfGifs, watchAddInitialSearchData} from "./search"
import {watchAddInitialGifData} from "./gif"
import {watchDeleteGif, watchEditGif, watchGetGif} from "./editGif"
import {watchAddGif} from "./addGif"

export default function* rootSaga() {
    yield all([
        watchAddChunkOfGifs(),
        watchAddInitialSearchData(),
        watchAddInitialGifData(),
        watchGetGif(),
        watchEditGif(),
        watchDeleteGif(),
        watchAddGif()
    ])
}
