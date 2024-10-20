<script setup lang="ts">

import ComponentA from './components/ComponentA.vue';
import ComponentB from './components/ComponentB.vue';
</script>

<template>
<main>
  <div class="container">
    <ComponentA/>
    <ComponentB/>
  </div>
</main>
</template>

<style scoped>
.container{
  display:flex;
  flex-direction: row;
}
</style>
