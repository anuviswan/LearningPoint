<template>
  <h1>Home</h1>
  <ul>
    <li v-for="task in currentTaskList" :key="task">{{ task }}</li>
  </ul>
</template>

<script>
import { computed } from "vue";
import { useStore } from "vuex";
export default {
  name: "Home",
  setup() {
    //const currentTaskList = ref(["sdsd", "sdsdsd"]);
    const store = useStore();
    const currentTaskList = computed(function() {
      return store.getters.AllDoto;
    });
    return { currentTaskList };
  },
};
</script>

<style></style>
