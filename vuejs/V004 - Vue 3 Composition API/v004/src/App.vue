<template>
  <div id="app">
    <form novalidate @submit.prevent="onSubmit">
      <InputName v-model="name" />
      <InputEmail v-model="email" />
      <button type="submit">Submit</button>
    </form>
  </div>
</template>

<script>
import InputName from "./components/InputName";
import InputEmail from "./components/InputEmail";
import { ref } from "vue";

export default {
  name: "App",
  components: {
    InputName,
    InputEmail,
  },

  setup() {
    const name = ref("");
    const email = ref("");

    function onSubmit() {
      console.log(name.value);
      console.log(email);
    }

    return {
      name,
      email,
      onSubmit,
    };
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
