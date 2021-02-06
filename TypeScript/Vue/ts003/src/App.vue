<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png" />
    <MessageBoard :msg="name" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import MessageBoard from "./components/HelloWorld.vue";
import { namespace } from "vuex-class";
const user = namespace("user");

@Component({
  components: {
    MessageBoard,
  },
})
export default class App extends Vue {
  @user.State
  public name!: string;
}
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
