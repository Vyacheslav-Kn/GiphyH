import {apiKey, endPoint, urlToSearchMethod} from "../common/configuration"

export const defaultLimit = 5
export const defaultOffset = 0

function generateQueryString({searchPhrase, params}) {
    let queryString = `${endPoint}${urlToSearchMethod}${searchPhrase}`

    Object.keys(params).forEach((key) => {
        queryString += `&${key}=${params[key]}`
    })

    return queryString
}

function memoizeSearch() {
    const generateKey = (searchPhrase, offset, limit) => `${searchPhrase} : ${offset} : ${limit}`
    const cachedResults = {}

    const mSearch = function search({searchPhrase, limit, offset}) {
        const params = {offset, limit, api_key: apiKey}
        const queryString = generateQueryString({searchPhrase, params})

        const key = generateKey(searchPhrase, offset, limit)
        const cachedResult = cachedResults[key]

        if(cachedResult) {
            console.log(`cached value for key = ${key}`)
            return Promise.resolve(cachedResult)
        }

        return fetch(queryString)
            .then(response => response.json())
            .then((responseJSON) => {
                cachedResults[key] = responseJSON.data
                return responseJSON.data
            })
            .catch(error => console.log(error))
    }

    return mSearch
}

export const searchGifsByPhrase = memoizeSearch()

export function getGifById(id) {
    const queryString = `${endPoint}${id}?api_key=${apiKey}`

    return fetch(queryString)
        .then(response => response.json())
        .then(responseJSON => responseJSON.data)
        .catch(error => console.log(error))
}
