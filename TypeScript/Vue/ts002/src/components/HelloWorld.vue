<template>
  <div class="hello">
    <h1>{{ fullMessage }}</h1>
    <div>
      <button @click="increment">Increment</button>
      Current Value :{{ this.count }}
    </div>
    <div>{{ countMessage }}</div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue, Watch } from "vue-property-decorator";

@Component
export default class HelloWorld extends Vue {
  @Prop() private msg!: string;

  private message = "Message From Props :";
  private count = 0;
  private countMessage = "Current Value is " + this.count;

  @Watch("count")
  countChanged(newValue: number) {
    this.countMessage = "Current Value is " + newValue;
  }

  get fullMessage(): string {
    return this.message + " " + this.msg;
  }

  public increment(): number {
    this.count++;
    return this.count;
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
