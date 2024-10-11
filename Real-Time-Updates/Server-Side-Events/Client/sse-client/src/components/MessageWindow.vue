<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'

const messages = ref<string[]>([]);
const eventSource = ref<EventSource>();

function initializeEventSSE(): EventSource {
    const eventSource = new EventSource('https://localhost:7226/demo/stream');

    eventSource.onmessage = (event: MessageEvent) => {
        messages.value.push(event.data);
    }

    return eventSource;
}

onMounted(() => {
    eventSource.value = initializeEventSSE();
})

onUnmounted(() => {
    eventSource.value?.close();
})
</script>
<template>
    <div>
        <ul class="scrollable-container">
            <li class="scrollable-list" v-for="(message, index) in messages" :key="index">
                {{ message }}
            </li>
        </ul>
    </div>
</template>

<style scoped>
.scrollable-container {
    width: 80%;
    /* Set a fixed width */
    height: 80vh;
    /* Set a fixed height for the scrollable area */
    overflow-y: auto;
    /* Enable vertical scrolling */
    border: 1px solid #ccc;
    /* Optional: Add a border */
    padding: 10px;
    /* Optional: Add some padding */
}

.scrollable-list {
    list-style-type: none;
    /* Remove default list styles */
    padding: 0;
    /* Remove default padding */
    margin: 0;
    /* Remove default margin */
}

.scrollable-list li {
    padding: 10px;
    border-bottom: 1px solid #ddd;
    /* Optional: Add dividers between items */
}
</style>