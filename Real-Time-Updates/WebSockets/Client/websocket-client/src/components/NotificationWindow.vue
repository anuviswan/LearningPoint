<script setup lang="ts">
import axios from 'axios';
async function Start() {
    console.log("starting api call")
    const response = await axios.post('https://localhost:7259/demo/StartTask');
    console.log(response)
    const taskId = response.data;

    console.log("triggered api call, taskId = " + taskId)
    console.log("start listening to web socket, taskId = " + taskId)
    const socket = new WebSocket(`wss://localhost:7259/WebSocket/ws?taskId=${taskId}`);
    socket.onopen = () => {
        console.log('WebSocket connection established.');
    };

    socket.onmessage = (event) => {
        console.log('Message from server:', event.data);
    };

    socket.onclose = () => {
        console.log('WebSocket connection closed.');
    };
}

</script>
<template>
    <main>
        <table>
            <thead>
                <tr>
                    <td><button @click="Start()">Start</button></td>
                </tr>

            </thead>
        </table>
    </main>
</template>