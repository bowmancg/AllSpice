import { AppState } from "../AppState"
import { Favorite } from "../models/Favorite"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class FavoritesService {

    async createFavorite(favoriteData) {
        const res = await api.post('api/favorites', favoriteData)
        logger.log('[Create favorite]', res.data)
        AppState.favorites.push(new Favorite(res.data))
        return res.data
    }
}

export const favoritesService = new FavoritesService()