<script setup lang="ts">
import { onMounted, onUnmounted, ref } from 'vue';
import eventBus from '@/eventBus';
const socket = ref<WebSocket | null>(null);

onMounted(() => {
    socket.value = new WebSocket(`wss://localhost:7259/WebSocket/ws`);
    socket.value.onopen = () => {
        console.log('WebSocket connection established.');
    };

    socket.value.onmessage = (event) => {
        console.log('Message from server:', event.data);
        var message = JSON.parse(event.data);
        console.log('Deserialized Message from server:', message);
        eventBus.emit('componentAMessage', message.Data);
    };

    socket.value.onclose = () => {
        console.log('WebSocket connection closed.');
    };
})

onUnmounted(() => {
    socket.value?.close();
})

</script>
<template>

</template>