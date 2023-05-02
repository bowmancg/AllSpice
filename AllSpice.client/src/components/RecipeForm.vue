<template>
    <form @submit.prevent="createRecipe()">
        <div class="mb-3">
            <label for="title" class="form-label">Recipe Title</label>
            <input type="text" placeholder="Recipe title" v-model="editable.title" required class="form-control" maxlength="30" id="title">
        </div>
        <div class="mb-3">
            <label for="img" class="form-label">Image</label>
            <input type="url" id="img" required placeholder="Image URL" v-model="editable.img" class="form-control">
        </div>
        <div class="mb-3">
            <label for="instructions" class="form-label">Instructions</label>
            <input type="text" maxlength="1000" required placeholder="Instructions" v-model="editable.instructions" id="instructions" class="form-control">
        </div>
        <div class="mb-3">
            <label for="category" class="form-label">Category</label>
            <input type="text" maxlength="30" required placeholder="Category" v-model="editable.category" id="category" class="form-control">
        </div>
        <button class="btn btn-success" data-bs-dismiss="modal" type="submit">Submit</button>
    </form>
</template>


<script>
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref, watchEffect } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { Modal } from 'bootstrap';
import { Recipe } from '../models/Recipe';
export default {
    setup() {
        const router = useRouter()
        const route = useRoute()
        const editable = ref({})
        return {
            route,
            editable,
            handleSubmit() {
                if (AppState.activeRecipe) {
                    this.editRecipe()
                } else {
                    this.createRecipe()
                }
            },
            async createRecipe() {
                try {
                    const recipeData = editable.value
                    const recipe = await recipesService.createRecipe(recipeData)
                    AppState.activeRecipe = null
                    await router.push({ name: 'RecipeDetails', params: { recipeId: recipe.id } })
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>