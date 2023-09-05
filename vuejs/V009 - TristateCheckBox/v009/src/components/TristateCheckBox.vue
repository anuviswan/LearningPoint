<template>
        <input type="checkbox" 
        v-bind:model="modelValue" 
        v-bind:checked="isChecked" 
        v-bind:indeterminate="isIndeterminate"
        v-on:input="$emit('update:modelValue', isChecked)"
        v-on:click="toggleState"
        />


</template>
<script setup>
import { onMounted, ref, defineProps, defineEmits } from 'vue';

const props = defineProps({
    modelValue: { type: Boolean, default: undefined }
})
defineEmits(['update:modelValue']);

const isIndeterminate = ref(false);
const isChecked = ref(false);


onMounted(() => {
  if (props.modelValue == undefined) {
    isIndeterminate.value = true;
  }
  else isChecked.value = props.modelValue
})

const toggleState = () => {

  if(isIndeterminate.value){
    isChecked.value = true;
    isIndeterminate.value = false;
  }
  else if(isChecked.value){
    isChecked.value = false;
    isIndeterminate.value = false;
  }
  else{
    isChecked.value = undefined;
    isIndeterminate.value = true;
  }
}

</script>
<style scoped>

</style>