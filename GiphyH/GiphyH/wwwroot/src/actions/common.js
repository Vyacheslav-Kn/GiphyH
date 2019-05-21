const createAction = (type, payload) => ({type, payload})

export const createActionCreatorsForRequest = ({request, success, fail}) => ({
    request: payload => createAction(request, payload),
    success: payload => createAction(success, payload),
    fail: payload => createAction(fail, payload)
})
