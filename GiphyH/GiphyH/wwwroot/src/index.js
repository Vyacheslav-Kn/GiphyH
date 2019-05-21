import React from "react"
import ReactDOM from "react-dom"
import {Provider} from "react-redux"

import {store, history} from "./store"
import App from "./components/App"

ReactDOM.render(
    <Provider store={store}>
        <App history={history} />
    </Provider>,
    window.root
)
