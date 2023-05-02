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
}

export const ingredientsService = new IngredientsService()