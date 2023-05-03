<template>
    <form @submit.prevent="searchRecipes()">
    <input type="text" v-model="search.query" id="Search" placeholder="Search" class="col-md-4 rounded-pill border-dark px-3">
    <button class="btn btn-border selectable" type="submit" title="search"><i class="mdi mdi-magnify"></i></button>
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { logger } from '../utils/Logger';
import { recipesService } from '../services/RecipesService';
export default {
    setup(){
        const search = reactive({
            query: ''
        })
    return {
        search,
        account: computed(() => AppState.account),
        async searchRecipes() {
            try {
                const query = search.query
                logger.log('Search Recipes', query)
                await recipesService.searchRecipes(query)
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