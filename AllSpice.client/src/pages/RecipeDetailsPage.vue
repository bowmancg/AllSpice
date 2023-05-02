<template>
    <div class="container">
        <section v-if="recipe" class="row">
            <div class="col-8">
                <h1>{{ recipe.title }}</h1>
            </div>
            <div class="col-12 col-md-6">
                <img :src="recipe.img" alt="" class="img-fluid">
            </div>
            <div class="col-12 col-md-6">
                <h4>Written by {{ recipe.creator.name }}</h4>
                <p>{{ recipe.instructions }}</p>
                <div v-for="i in ingredients">
                    <ul>
                        <IngredientCard :ingredient="i" />
                    </ul>
                </div>
            </div>
        </section>
        <section class="row justify-content-between m-3">
            <div class="col-md-3">
                <button class="btn btn-info border selectable rounded-pill" v-if="reicpe?.creatorId == account?.id" data-bs-toggle="modal" data-bs-target="#recipeModal">Edit Recipe</button>
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
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { router } from '../router';
import IngredientForm from '../components/IngredientForm.vue';
import IngredientCard from '../components/IngredientCard.vue';
export default {
    setup() {
        const editable = ref({});
        // onMounted(() => {
        //     getRecipeById()
        // })
        const route = useRoute();
        async function getRecipeById() {
            try {
                await recipesService.getRecipeById(route.params.recipeId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        onMounted(() => {
            getRecipeById();
        });
        return {
            editable,
            route,
            recipe: computed(() => AppState.activeRecipe),
            account: computed(() => AppState.account),
            async deleteRecipe(recipeId) {
                try {
                    if (await Pop.confirm("Are you sure you want to delete this?")) {
                        await recipesService.deleteRecipe(recipeId);
                        // await router.push({ name: 'HomePage', params:  })
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