<template>
  <h1>Home</h1>
  <ul>
    <li v-for="task in currentTaskList" :key="task">{{ task }}</li>
  </ul>
</template>

<script>
import { ref } from "vue";
export default {
  name: "Home",
  setup() {
    const currentTaskList = ref(["sdsd", "sdsdsd"]);
    return { currentTaskList };
  },
};
</script>

<style></style>
