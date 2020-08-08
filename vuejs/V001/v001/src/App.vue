<template>
  <div id="app">
    <Header />
    <AddTodo v-on:add-todo="addTodo" />
    <Todos v-bind:todos="todos" v-on:del-todo="deleteTodo" />
  </div>
</template>

<script>
import Todos from "./components/Todos";
import Header from "./components/layout/Header";
import AddTodo from "./components/AddToDo";
import axios from "axios";

export default {
  name: "App",
  components: { Todos, Header, AddTodo },
  data() {
    return {
      todos: [],
    };
  },
  methods: {
    async addTodo(newTodo) {
      const { title, completed } = newTodo;
      var response = await axios.post(
        "https://jsonplaceholder.typicode.com/todos",
        {
          title,
          completed,
        }
      );
      this.todos = [...this.todos, response.data];
    },
    async deleteTodo(id) {
      await axios.delete(`https://jsonplaceholder.typicode.com/todos/${id}`);
      this.todos = this.todos.filter((todo) => todo.id != id);
    },
  },
  async created() {
    const response = await axios.get(
      "https://jsonplaceholder.typicode.com/todos?_limit=5"
    );
    this.todos = response.data;
  },
};
</script>

<style>
* {
  box-sizing: border-box;
  margin: 0;
  padding: 0;
}

body {
  font-family: Arial, Helvetica, sans-serif;
  line-height: 1.4;
}

.btn {
  display: inline-block;
  background: #555;
  color: #fff;
  padding: 7px 20px;
  cursor: pointer;
}

.btn:hover {
  background: #666;
}
</style>
