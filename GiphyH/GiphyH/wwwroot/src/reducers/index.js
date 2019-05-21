import {combineReducers} from "redux"
import {connectRouter} from "connected-react-router"
import {reducer as formReducer} from "redux-form"

import gifReducer from "./gif"
import searchReducer from "./search"
import editGifReducer from "./editGif"
import addGifReducer from "./addGif"

export default history => combineReducers({
    router: connectRouter(history),
    form: formReducer,
    gif: gifReducer,
    search: searchReducer,
    editGif: editGifReducer,
    addGif: addGifReducer
})
