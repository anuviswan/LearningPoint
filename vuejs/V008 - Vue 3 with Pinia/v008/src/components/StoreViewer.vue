<template>
    <div>
        <div>
            <table class="styled-table">
                <thead>
                    <tr>
                        <td>Key</td>
                        <td>Value</td>
                    </tr>
                </thead>
                <tbody>

                    <tr>
                        <td>User Name</td>
                        <td>{{ user.userName }}</td>
                    </tr>
                    <tr>
                        <td>Age</td>
                        <td>{{ user.age }}</td>
                    </tr>
                    <tr>
                        <td>Senior Citizen</td>
                        <td>{{ IsSeniorCitizen ? 'Yes' : ' No' }}</td>
                    </tr>
                    <tr>
                        <td>Counter</td>
                        <td>{{ counter }}</td>
                    </tr>
                    <tr>
                        <td colspan="2"><router-link class="styled-router-link" to="/edit">Edit Store</router-link></td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

</template>
<script setup lang="ts">
import { ref } from "vue";
import { useUserStore } from "@/stores/userStore";
import { storeToRefs } from "pinia";

const counter = ref(1);
const userStore = useUserStore();
const { user } = storeToRefs(userStore);
const { IsSeniorCitizen } = userStore;
</script>

<style scoped>

.styled-table {
    border-collapse: collapse;
    margin: 25px 0;
    font-size: 0.9em;
    font-family: sans-serif;
    min-width: 400px;
    box-shadow: 0 0 20px rgba(0, 0, 0, 0.15);
}

.styled-table thead tr {
    background-color: #009879;
    color: #ffffff;
    text-align: left;
}

.styled-table th,
.styled-table td {
    padding: 12px 15px;
}

.styled-table tbody tr {
    border-bottom: 1px solid #dddddd;
}

.styled-table tbody tr:nth-of-type(even) {
    background-color: #f3f3f3;
}

.styled-table tbody tr:last-of-type {
    border-bottom: 2px solid #009879;
}
</style>