import {createBrowserHistory} from "history"
import {applyMiddleware, createStore} from "redux"
import {routerMiddleware} from "connected-react-router"
import {composeWithDevTools} from "redux-devtools-extension/developmentOnly"
import createSagaMiddleware from "redux-saga"

import createRootReducer from "../reducers"
import rootSaga from "../sagas"
import errorMiddleware from "../middleware/error"

export const history = createBrowserHistory()
const sagaMiddleware = createSagaMiddleware()

export const store = createStore(
    createRootReducer(history),
    composeWithDevTools(
        applyMiddleware(
            routerMiddleware(history),
            sagaMiddleware,
            errorMiddleware
        )
    )
)
sagaMiddleware.run(rootSaga)
