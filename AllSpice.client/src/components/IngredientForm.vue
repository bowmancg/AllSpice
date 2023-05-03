<template>
    <form @submit.prevent="createIngredient()">
    <div class="mb-3">
        <label for="name" class="form-label">Ingredient Name</label>
        <input type="text" placeholder="Ingredient name" v-model="editable.name" required maxlength="30" id="name">
    </div>
    <div class="mb-3">
        <label for="quantity" class="form-label">Quantity</label>
        <input type="text" placeholder="Quantity" v-model="editable.quantity" required maxlength="30" id="quantity" class="form-control">
    </div>
    <button class="btn btn-success" data-bs-dismiss="modal" type="submit">Submit</button>
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop';
import { ingredientsService } from '../services/IngredientsService';
import { useRoute } from 'vue-router';
export default {
    setup(){
        const editable = ref({})
        const route = useRoute()
    return {
        editable,
        async createIngredient() {
            try {
                const ingredientData = editable.value
                ingredientData.recipeId = route.params.recipeId
                await ingredientsService.createIngredient(ingredientData)
                editable.value = {}
            } catch (error) {
                Pop.error(error)
            }
        }
    }
    }
};
</script>


<style lang="scss" scoped>

</style>