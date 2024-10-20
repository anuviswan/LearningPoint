<script setup lang="ts">
import {ref} from 'vue'
const data = ref<string>('');
</script>
<template>
    <main>
        <div>
            <h1>Component B</h1>
            <div>{{ data }}</div>
        </div>
    </main>
</template>

<style scoped>
.container{
    display: flex;
    flex-direction: column;
}
</style>