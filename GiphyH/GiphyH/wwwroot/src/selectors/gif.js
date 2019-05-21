import {createSelector} from "reselect"

const getGif = state => state.gif.beforeLoadedGif

export const getGifId = state => state.gif.gifId
export const getHasComeAfterSearching = state => state.gif.hasComeAfterSearching

function reduceAuthor(author) {
    return {
        id: author.id,
        avatarUrl: author.avatar_url,
        name: author.display_name
    }
}

function reduceGif(gif) {
    const {id, title, user} = gif

    if(!id) {
        return {}
    }

    const author = user ? reduceAuthor(user) : null

    return {
        id,
        title,
        author,
        imageUrl: gif.images.original.url,
        publicationDate: gif.import_datetime
    }
}

export const getReducedGif = createSelector(
    [getGif],
    reduceGif
)
