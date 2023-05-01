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
            </div>
        </section>

    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
export default {
    setup(){
        onMounted(() => {
            getRecipeById()
        })
        const route = useRoute()
        async function getRecipeById() {
            try {
                await recipesService.getRecipeById(route.params.recipeId)
            } catch (error) {
                Pop.error(error)
            }
        }
    return {
        recipe: computed(() => AppState.activeRecipe)
    }
    }
};
</script>


<style lang="scss" scoped>

</style>