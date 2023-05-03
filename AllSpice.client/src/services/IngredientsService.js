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
        const res =  await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log('[get ingredients]', res.data)
        AppState.ingredients = res.data.map(i => new Ingredient(i))
    }
}

export const ingredientsService = new IngredientsService()