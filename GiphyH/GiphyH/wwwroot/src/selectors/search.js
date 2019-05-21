import {createSelector} from "reselect"

const getGifs = state => state.search.gifs

export const getSearchProperties = state => state.search.searchProperties

function reduceGifs(gifs) {
    return gifs.map(gif => ({
        id: gif.id,
        imageUrl: gif.images.fixed_height_small.url
    }))
}

export const getReducedGifs = createSelector(
    [getGifs],
    reduceGifs
)
