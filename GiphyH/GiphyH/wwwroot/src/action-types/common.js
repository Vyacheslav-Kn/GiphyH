import _ from "lodash"

const stages = {
    request: "_REQUEST",
    success: "_SUCCEED",
    fail: "_FAILED"
}

export const createRequestActionTypes = (requestName) => {
    const name = requestName.toUpperCase()

    return _.mapValues(stages, val => `${name}${val}`)
}
