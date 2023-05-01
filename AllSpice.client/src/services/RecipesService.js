import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class RecipesService {

    async getRecipes() {
        const res = await api.get('api/recipes')
        logger.log('[found recipes]', res.data)
        AppState.recipes = res.data.map(r => new Recipe(r))
    }

    async getRecipeById(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}`)
        logger.log('[found a recipe]', res.data)
        AppState.activeRecipe = new Recipe(res.data)
    }

    async createRecipe(recipeData) {
        const res = await api.post('api/recipes', recipeData)
        logger.log('[created recipe]')
        AppState.recipes.push(new Recipe(res.data))
        return res.data
    }
}

export const recipesService = new RecipesService()