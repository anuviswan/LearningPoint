<template>
  <form  @submit.prevent="onManualSubmit">
    <label for="name">Name</label>
    <input id="name" type="text" v-model="name"/>

    <label for="name">Caption</label>
    <input id="name" type="text" v-model="caption"/>

    <button>Click</button>
  </form>
</template>

<script>
import  useVuelidate  from '@vuelidate/core';
import { required} from '@vuelidate/validators';
export default {
  name: 'HelloWorld',

  data(){
    return {
      v$: useVuelidate() ,
      name : '',
      caption : '',
    }
  },
    validations () {
    return{
      name : {required},
      caption : {required}
    }
  },
  methods:{
    onManualSubmit(){
      console.log("Name='"+this.name+"',Caption='"+this.caption+"'");
      console.log(this.v$)
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
