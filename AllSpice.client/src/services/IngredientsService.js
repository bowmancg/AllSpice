import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"


class IngredientsService {

    async createIngredient(ingredientData) {
        const res = await api.post('api/ingredients', ingredientData)
        logger.log('[Created ingredient]', res.data)
        AppState.ingredients.push(new Ingredient(res.data))
        return res.data
    }

    async getIngredientsByRecipeId(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log('[Recipe Ingredients]', res.data)
        AppState.ingredients = res.data
    }

    async deleteIngredient(ingredientId) {
        const res = await api.delete(`api/ingredients/${ingredientId}`)
        logger.log('[Delete Ingredient]', res.data)
        AppState.ingredients = AppState.ingredients.filter(i => i.ingredientId != ingredientId)
        logger.log(AppState.ingredients)
    }
}

export const ingredientsService = new IngredientsService()