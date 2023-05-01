<template>
    <form @submit.prevent="createRecipe()">
        <div class="mb-3">
            <label for="title" class="form-label">Recipe Title</label>
            <input type="text" placeholder="Recipe title" required class="form-control" maxlength="30" id="title">
        </div>
        <div class="mb-3">
            <label for="img" class="form-label">Image</label>
            <input type="url" id="img" required placeholder="Image URL" class="form-control">
        </div>
        <div class="mb-3">
            <label for="instructions" class="form-label">Instructions</label>
            <input type="text" maxlength="1000" required placeholder="Instructions" id="instructions" class="form-control">
        </div>
        <div class="mb-3">
            <label for="category" class="form-label">Category</label>
            <input type="text" maxlength="30" required placeholder="Category" id="category" class="form-control">
        </div>
        <button class="btn" data-bs-dismiss="modal" type="submit">Submit</button>
    </form>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
export default {
    setup() {
        const route = useRoute()
        return {
            route,
            
        }
    }
};
</script>


<style lang="scss" scoped></style>