import {createRequestActionTypes} from "./common"

const editGifRequest = "editGif"
const deleteGifRequest = "deleteGif"
const getGifRequest = "getGif"

export const editGifTypes = createRequestActionTypes(editGifRequest)

export const deleteGifTypes = createRequestActionTypes(deleteGifRequest)

export const getGifTypes = createRequestActionTypes(getGifRequest)
