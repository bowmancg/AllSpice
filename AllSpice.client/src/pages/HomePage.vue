<template>
  <div class="container-fluid">
    <h2>Choose a Recipe!</h2>
    <RecipeSearchBar />
    <button class="border btn btn-primary rounded-pill selectable col-2 mb-3" data-bs-toggle="modal" data-bs-target="#recipeModal">Create Recipe</button>
    <section class="row">
      <div v-for="r in recipes" class="col-6 col-md-3 mb-3">
        <RecipeCard :recipe="r" />
      </div>
    </section>
  </div>
  <Modal id="recipeModal">
    <template #header>
      <h5>Create Recipe</h5>
    </template>
    <template #modalBody>
      <RecipeForm />
    </template>
  </Modal>
</template>

<script>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { AppState } from '../AppState';
import RecipeCard from '../components/RecipeCard.vue';
import RecipeForm from '../components/RecipeForm.vue';
import RecipeSearchBar from '../components/RecipeSearchBar.vue';

export default {
    setup() {
        onMounted(() => {
            getRecipes();
        });
        async function getRecipes() {
            try {
                await recipesService.getRecipes();
            }
            catch (error) {
                Pop.error(error);
            }
        }
        return {
            recipes: computed(() => AppState.recipes)
        };
    },
    components: { RecipeCard, RecipeForm, RecipeSearchBar }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;



  .home-card {
    width: 50vw;

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
