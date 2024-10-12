<script setup lang="ts">
import axios from 'axios';
import { ref, onMounted, onBeforeUnmount } from 'vue';
import Alert from '@/components/Alert.vue'
import eventBus from '@/eventBus';

const showAlert = ref<boolean>();
const messages = ref<string[]>([]);

async function Start() {
    const response = await axios.post('https://localhost:7259/demo/StartTask');
    messages.value = [...messages.value, 'Triggered Task A'];
    console.log('pushed message')
}

const handleMessage = (msg: string) => {
    messages.value = [...messages.value, msg];
};
onMounted(() => {
    eventBus.on('componentAMessage', handleMessage);
});

onBeforeUnmount(() => {
    eventBus.off('componentAMessage', handleMessage);
});
</script>
<template>
    <main>
        <table>
            <thead>
                <tr>
                    <td><button @click="Start()">Start</button></td>
                </tr>
            </thead>
            <tbody>
                <tr v-for="(message, index) in messages" :key="index">
                    <td>
                        <Alert type="success" dismissible :message=message @close="showAlert = false" />
                    </td>
                </tr>
            </tbody>
        </table>
    </main>
</template>