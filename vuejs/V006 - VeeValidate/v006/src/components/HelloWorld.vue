<template>
  <form @submit.prevent="onPlayButtonClicked">
    <label for="name">Name</label>
    <input id="name" type="text" v-model="myname"/>
    
    <ChildComponent v-model="caption"/>
    <button v-on:click="onSubmit">Click To Submit</button>
  </form>
</template>

<script>
import ChildComponent from "./ChildComponent.vue"
export default {
  name: 'HelloWorld',
  components: {ChildComponent},
  data(){
    return {
      myname : '',
      caption: ''
    };
  },
  methods:{
    onSubmit(){

      console.log("Attempting to submit form");
    }
  }
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
