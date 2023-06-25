<template>
  <form  @submit.prevent="onManualSubmit">
    <label for="name">Name</label>
    <!-- <input id="name" type="text" v-model="name"/> -->


  <input v-model="name">
  <div v-if="v$.name.$error">Name field has an error.</div>


<p
  v-for="error of v$.name.$errors"
  :key="error.$uid"
>
<span v-if="v$.name.required" class="error">Name is a Required field.</span>
</p>


    <!-- <label for="name">Caption</label>
    <input id="name" type="text" v-model="caption"/> -->

    <button>Click</button>
  </form>
</template>

<script>
import  useVuelidate  from '@vuelidate/core';
import { required} from '@vuelidate/validators';
export default {
  name: 'HelloWorld',
  setup(){
    return {
      v$: useVuelidate() ,
    }
  },
  data(){
    return {
     
      name : '',
    }
  },
    validations () {
    return{
      name : {required, $autoDirty: true},
    }
  },
  methods:{
     async onManualSubmit(){
      var result = await this.v$.$validate();
      console.log(result);
      //console.log("Name='"+this.name+"'");
      console.log(this.v$.name.$error);
      console.log(this.v$);
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
