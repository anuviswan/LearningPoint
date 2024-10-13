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
        <!-- <table>
            <tr>
                <td class="vertical-text-container">
                    <div class="vertical-text">Component A</div>
                </td>
                <td>
                    <table class="data">
                        <thead>
                            <tr>
                                <th><button @click="Start()">Start</button></th>
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
                </td>
            </tr>
        </table>
         -->
        <div class="container">
            <table class="layout-table">
                <tr>
                    <!-- Title column spanning the full height -->
                    <td class="title-column">
                        <div class="rotated-title">Proc A</div>
                    </td>

                    <!-- Content column -->
                    <td class="content-column">
                        <!-- Top part with button -->
                        <div class="top-section">
                            <button @click="Start()">Trigger Process</button>
                        </div>

                        <!-- Bottom part with textarea -->
                        <div class="bottom-section">
                            <table>
                                <tbody>
                                    <tr v-for="(message, index) in messages" :key="index">
                                        <td>
                                            <Alert type="success" dismissible :message=message
                                                @close="showAlert = false" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>

    </main>
</template>
<style scoped>
.container {
    height: 100vh;
    width: 100%;
}

.layout-table {
    width: 100%;
    height: 100%;
    border-collapse: collapse;
}

.title-column {
    width: 5%;
    background-color: green;
    /* Light blue background */
    text-align: center;
    vertical-align: middle;

}

.rotated-title {
    transform: rotate(-90deg);
    white-space: nowrap;
    display: inline-block;
    font-size: x-large;
    font-weight: bold;
    color: white;
}

.content-column {
    width: 95%;
}

.top-section {
    height: 5%;
    display: flex;
    align-items: center;
    justify-content: center;
    background-color: green
}

.bottom-section {
    height: 95%;
    padding: 1rem;
}

textarea {
    width: 100%;
    height: 100%;
    resize: none;
}
</style>