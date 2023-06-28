<template>
<input type="text" v-model="modeValue"/>
<p v-if="v$.modelValue.$error">
      <span v-if="v$.modelValue.required" class="error">Description is a Required field.</span>
    </p>
</template>

<script>
import  useVuelidate  from '@vuelidate/core';
import { required} from '@vuelidate/validators';
export default{
 name:'ChildComponent',
 setup(){
    return {
      v$: useVuelidate() ,
    }
  },
 props:{
     modelValue:String
 },
 validations () {
    return{
      modelValue : {required},
     
    }   
}
}
</script>
<style scoped>
</style>