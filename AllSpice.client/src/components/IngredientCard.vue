<template>
    <div class="row">
        <div class="elevation-3">
            <p>{{ ingredient.name }}</p>
            <p>{{ ingredient.quantity }}</p>
            <span v-if="creatorId == account?.id" @click="deleteIngredient(ingredient.id)"
                class="mdi mdi-delete selectable"></span>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { ingredientsService } from '../services/IngredientsService'
import { Ingredient } from '../models/Ingredient';
import Pop from '../utils/Pop';
import { Account } from '../models/Account';
export default {
    props: {
        ingredient: { type: Ingredient, required: true },
        creatorId: { type: Number, required: true },
        account: { type: Account} 
    },
    setup() {
        return {
            ingredients: computed(() => AppState.ingredients),
            async deleteIngredient(ingredientId) {
                try {
                    await ingredientsService.deleteIngredient(ingredientId)
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>