const errorMiddleware = () => next => (action) => {
    const {payload, type} = action

    if(type.endsWith("_FAILED")) {
        const {error} = payload
        console.error(error)
        return
    }

    next(action)
}

export default errorMiddleware
