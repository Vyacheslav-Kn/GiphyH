import {getGifTypes, editGifTypes, deleteGifTypes} from "../action-types/editGif"
import {createActionCreatorsForRequest} from "./common"

export const getGifCreators = createActionCreatorsForRequest(getGifTypes)

export const editGifCreators = createActionCreatorsForRequest(editGifTypes)

export const deleteGifCreators = createActionCreatorsForRequest(deleteGifTypes)
