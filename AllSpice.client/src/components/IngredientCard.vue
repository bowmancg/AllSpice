<template>
    <div class="card elevation-3">
        <p class="fs-4">{{ ingredient.name }}</p>
        <p class="fs-5">{{ ingredient.quantity }}</p>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Ingredient } from '../models/Ingredient';
import { Ingredient } from '../models/Ingredient';
export default {
    props: { ingredient: { type: Ingredient, required: true } },
    setup(){
    return {
        ingredients: computed(() => AppState.ingredients)
    }
    }
};
</script>


<style lang="scss" scoped>

</style>