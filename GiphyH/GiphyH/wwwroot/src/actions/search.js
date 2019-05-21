import {searchGifTypes, getChunkOfGifsTypes} from "../action-types/search"
import {createActionCreatorsForRequest} from "./common"

export const searchCreators = createActionCreatorsForRequest(searchGifTypes)

export const chunkOfGifsCreators = createActionCreatorsForRequest(getChunkOfGifsTypes)
