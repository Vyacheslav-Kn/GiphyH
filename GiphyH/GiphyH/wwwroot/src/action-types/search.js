import {createRequestActionTypes} from "./common"

const searchGifRequest = "searchGif"
const chunkOfGifsRequest = "chunkOfGifs"

export const searchGifTypes = createRequestActionTypes(searchGifRequest)
export const getChunkOfGifsTypes = createRequestActionTypes(chunkOfGifsRequest)
