<script setup lang="ts">
import {ref} from 'vue'
import { emitter } from '@/types/emitter'
const data = ref<string>('');
emitter.on('foo', (e) => 
{
    console.log('recieved ' + e); 
    data.value += e
}); // 'e' has inferred type 'string'
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