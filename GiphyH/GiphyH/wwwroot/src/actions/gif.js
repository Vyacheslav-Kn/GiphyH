import {getInitialGifTypes} from "../action-types/gif"
import {createActionCreatorsForRequest} from "./common"

export const getInitialGifCreators = createActionCreatorsForRequest(getInitialGifTypes)
