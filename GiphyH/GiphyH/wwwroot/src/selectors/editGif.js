import {createSelector} from "reselect"

const getGifForEdition = state => state.editGif.gif

export const getEditMessage = state => state.editGif.editMessage
export const getDeleteMessage = state => state.editGif.deleteMessage
export const getHasComeAfterSearching = state => state.editGif.hasComeAfterSearching

function reduceGifForEdition(gif) {
    const {id, title, import_datetime} = gif

    if(!id) {
        return {}
    }

    return {
        id,
        title,
        publicationDate: import_datetime.replace(/\s/, "T")
    }
}

export const getReducedGifForEdition = createSelector(
    [getGifForEdition],
    reduceGifForEdition
)
