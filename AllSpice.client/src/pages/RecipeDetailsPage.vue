<template>
    <div class="container">
        <section v-if="recipe" class="row">
            <div class="col-8">
                <h1>{{ recipe.title }}</h1>
            </div>
            <div class="col-12 col-md-6">
                <img :src="recipe.img" alt="" class="img-fluid rounded elevation-3">
            </div>
            <div class="col-12 col-md-6">
                <h4>Written by {{ recipe.creator.name }}</h4>
                <p>{{ recipe.instructions }}</p>
                <div v-for="i in ingredients">
                        <IngredientCard :ingredient="i" />
                </div>
            </div>
        </section>
        <section class="row justify-content-between m-3">
            <div class="col-md-3">
                <button class="btn btn-info border selectable rounded-pill" v-if="recipe?.creatorId == account?.id" data-bs-toggle="modal" data-bs-target="#recipeModal">Edit Recipe</button>
            </div>
            <div class="col-md-3">
                <button class="btn btn-danger border selectable rounded-pill" v-if="recipe?.creatorId == account?.id" @click="deleteRecipe(recipe.id)">Delete Recipe</button>
            </div>
            <div class="col-md-3">
                <button class="btn btn-info border selectable rounded-pill" v-if="recipe?.creatorId == account?.id" data-bs-toggle="modal" data-bs-target="#ingredientModal">Add Ingredient</button>
            </div>
        </section>
    </div>
    <Modal id="recipeModal">
        <template #header>
            <h5>Edit Recipe</h5>
        </template>
        <template #modalBody>
            <RecipeForm />
        </template>
    </Modal>
    <Modal id="ingredientModal">
        <template #header>
            <h5>Ingredients</h5>
        </template>
        <template #modalBody>
            <IngredientForm />
        </template>
    </Modal>
</template>


<script>
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref, watchEffect } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import IngredientForm from '../components/IngredientForm.vue';
import IngredientCard from '../components/IngredientCard.vue';
import { ingredientsService } from '../services/IngredientsService';
export default {
    setup() {
        const editable = ref({});
        const router = useRouter()
        const route = useRoute();
        async function getRecipeById() {
            try {
                await recipesService.getRecipeById(route.params.recipeId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getIngredientsByRecipeId() {
            try {
                let recipeId = route.params.recipeId
                await ingredientsService.getIngredientsByRecipeId(recipeId)
            } catch (error) {
                Pop.error(error)
            }
        }
        watchEffect(() => {
            route.params.recipeId
            getRecipeById();
            getIngredientsByRecipeId()
        });
        return {
            editable,
            route,
            ingredients: computed(() => AppState.ingredients),
            recipe: computed(() => AppState.activeRecipe),
            account: computed(() => AppState.account),
            async deleteRecipe(recipeId) {
                try {
                    if (await Pop.confirm("Are you sure you want to delete this?")) {
                        await recipesService.deleteRecipe(recipeId);
                        router.push({ name: 'Home' })
                    }
                }
                catch (error) {
                    Pop.error(error);
                }
            }
        };
    },
    components: { IngredientForm, IngredientCard }
};
</script>


<style lang="scss" scoped></style>