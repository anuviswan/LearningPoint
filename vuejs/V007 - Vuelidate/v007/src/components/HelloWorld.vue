<template>
  <form  @submit.prevent="onManualSubmit">
    <label for="name">Name</label>
    <input id="name" type="text" v-model="name"/>
    <p v-if="v$.name.$error">
      <span v-if="v$.name.required" class="error">Name is a Required field.</span>
    </p>

    <label for="caption">Caption</label>
    <input id="caption" type="text" v-model="caption"/>
    <p v-if="v$.caption.$error">
      <span v-if="v$.caption.required" class="error">Caption is a Required field.</span>
    </p>

    <label for="description">Description</label>
    <ChildComponent v-model="description"/>

    <button>Click</button>
  </form>
</template>

<script>
import  useVuelidate  from '@vuelidate/core';
import { required} from '@vuelidate/validators';
import ChildComponent from "./ChildComponent.vue"
export default {
  name: 'HelloWorld',
  setup(){
    return {
      v$: useVuelidate() ,
    }
  },
  components:{ ChildComponent},
  data(){
    return {
      name : '',
      caption:'',
      description:''
    }
  },
    validations () {
    return{
      name : {required},
      caption : {required},
      description:{required}
    }
  },
  methods:{
     async onManualSubmit(){
      await this.v$.$validate();
     // this.v$.$reset();
    }
  },

}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
