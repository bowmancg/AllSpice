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

    async editRecipe(recipeData, recipeId) {
        const res = await api.put(`api/recipes/${recipeId}`, recipeData)
        logger.log('Edit Recipe', res.data)
        AppState.activeRecipe = new Recipe(res.data)
    }

    async deleteRecipe(recipeId) {
        const res = await api.delete(`api/recipes/${recipeId}`)
        logger.log('Deleted Recipe', res.data)
        AppState.recipes = AppState.recipes.filter(r => r.activeRecipe != recipeId)
    }

    async searchRecipes(query) {
        const res = await api.get('api/recipes', { params: { query: query } })
        logger.log('[Searching Recipes]', res.data)
        AppState.query = query.query
        AppState.recipes = res.data.map(r => new Recipe(r))
    }

    async clearSearch() {
        AppState.query = ''
        this.getRecipes()
    }
}

export const recipesService = new RecipesService()