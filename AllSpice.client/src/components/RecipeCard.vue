<template>
    <div class="card text-center elevation-5">
        <div>
            <img :src="recipe.img" alt="" class="img-fluid">
        </div>
        <div class="p-2">
            <router-link :to="{ name: 'RecipeDetails', params: { recipeId: recipe.id } }">
            <h4>{{ recipe.title }}</h4>
            </router-link>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
export default {
    props: { recipe: { type: Recipe, required: true } },
    setup(){
    return {  }
    }
};
</script>


<style lang="scss" scoped>

</style>