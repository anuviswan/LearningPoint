<template>
        <input type="checkbox" 
        v-bind:model="modelValue" 
        v-bind:checked="isChecked" 
        v-bind:indeterminate="isIndeterminate"
        @input="$emit('update:modelValue', isChecked)"
        />


</template>
<script setup>
import { onMounted, ref, defineProps } from 'vue';

const props = defineProps({
    modelValue: { type: Boolean, default: undefined }
})

const isChecked = ref<Boolean | undefined>(false)
const isIndeterminate = ref(false)

onMounted(() => {
  if (props.modelValue == undefined) isIndeterminate.value = true
  else isChecked.value = props.modelValue
})

</script>
<style scoped>

</style>