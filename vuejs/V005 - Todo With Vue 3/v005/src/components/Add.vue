<template>
  <h2>Add</h2>
  <div>
    <form>
      <div class="form-group">
        <label for="inputTodo">Todo Item</label>
        <input
          class="form-control"
          type="text"
          id="inputTodo"
          v-model="inputText"
        />
      </div>
      <div class="form-group">
        <input type="submit" value="Add" v-on:click="onSubmit" />
      </div>
    </form>
  </div>
</template>

<script>
import { ref } from "vue";
import { useStore } from "vuex";
export default {
  name: "Add",
  setup() {
    const inputText = ref("");
    const store = useStore();

    const onSubmit = (e) => {
      e.preventDefault();
      console.log(inputText.value);
      store.dispatch("addTodo", inputText.value);
      console.log(store.getters.AllDoto);
    };
    return { inputText, onSubmit };
  },
};
</script>

<style></style>
