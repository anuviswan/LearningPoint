<script setup lang="ts">
import { ref } from 'vue';

interface Props {
    type?: string,
    canClose?: boolean,
    message: string
}

const props = withDefaults(defineProps<Props>(), {
    type: 'Sucess',
    message: '',
    canClose: true
})

// Define props for customization
// const props = defineProps<{
//     type?: 'success' | 'error' | 'info' | 'warning';
//     dismissible?: boolean;
//     message: string;
// }>({
//     type: 'info', // Default type is 'info'
//     dismissible: false, // Default is not dismissible
// });

// Emit events to parent component
const emit = defineEmits(['close']);

// Reactive state to control visibility
const isVisible = ref(true);

// Close alert method
const closeAlert = () => {
    isVisible.value = false;
    setTimeout(() => {
        emit('close');
    }, 300); // Ensure the transition completes before emitting close
};



</script>

<template>
    <transition name="fade-slide">
        <div v-if="isVisible" :class="['alert', `alert--${props.type}`]">
            <span>{{ props.message }}</span>
            <button v-if="props.canClose" class="alert__close-btn" @click="closeAlert">
                &times;
            </button>
        </div>
    </transition>
</template>

<style scoped>
/* Base styles for the alert */
.alert {
    padding: 15px;
    margin: 15px 0;
    border-radius: 4px;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

/* Color variations for different alert types */
.alert--success {
    background-color: #d4edda;
    color: #155724;
}

.alert--error {
    background-color: #f8d7da;
    color: #721c24;
}

.alert--info {
    background-color: #d1ecf1;
    color: #0c5460;
}

.alert--warning {
    background-color: #fff3cd;
    color: #856404;
}

/* Styles for the close button */
.alert__close-btn {
    background: none;
    border: none;
    font-size: 20px;
    line-height: 1;
    cursor: pointer;
    color: inherit;
}

/* Transition for fade and slide effect */
.fade-slide-enter-active,
.fade-slide-leave-active {
    transition: opacity 0.3s ease, transform 0.3s ease;
}

/* Start state for entering (faded out and slid up) */
.fade-slide-enter-from {
    opacity: 0;
    transform: translateY(-10px);
}

/* End state for leaving (faded out and slid up) */
.fade-slide-leave-to {
    opacity: 0;
    transform: translateY(-10px);
}
</style>
