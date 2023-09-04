<template>
  <div class="hello">
    <h1>Demo for Tristate checkbox</h1>
    <p>
      This is a demo for tristate checkbox
    </p>
    <ul>
      <li>
        <TristateCheckBoxVue v-model="ModelValue" /> <label>{{ CaptionText }}</label>
      </li>
    </ul>
    <ul>
      <li>
        Current Value of Model : {{ ModelValue == undefined ? "indeterminate" : ModelValue }}
      </li>
    </ul>
  </div>
</template>

<script setup>
import TristateCheckBoxVue from "./TristateCheckBox.vue";
import {ref} from "vue"

const ModelValue = ref(undefined); 
const CaptionText = ref("Change state of checkbox");

console.log(ModelValue.value)

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
