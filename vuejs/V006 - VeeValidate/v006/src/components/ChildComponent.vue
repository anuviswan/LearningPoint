<template>
<ValidationProvider rules="required" v-slot="{ errors }">
<label for="name">Caption</label>
<Field type='text' :value="modelValue" @input="$emit('update:modelValue', event.target.value)" v-validate='required'/>
<span>{{ errors[0] }}</span>
</ValidationProvider>
</template>

<script>
import { ValidationProvider , Field} from 'vee-validate';
// import './validations.js'

export default{
    name: 'ChildComponent',
    components: {ValidationProvider, Field},
    props:{
        modelValue: String
    },
    emits: ['update:modelValue'],

    data(){
        return {

        }
    },


}
</script>

<style scoped>
</style>
