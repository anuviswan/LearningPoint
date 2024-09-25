<template>
  <div>
    <h2>Apollo GraphQL Demo</h2>
    <div class="row">
      <div class="column">
        <div>
            <input type="button" value="Fetch Movies">
        </div>
        <div>
            <input type="button" value="Fetch Movies">
        </div>
        <div>
            <input type="button" value="Fetch Movies">
        </div>

      </div>
      <div class="column">
        <div v-if="loading">Loading...</div>
        <div v-else>
          <div v-for="(film,index) in data.result.value.allFilms.films" :key="index">
            <h2>{{film.title}}</h2>
            <div>{{film.director}}</div>
            <pre>{{film.releaseDate}}</pre>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>

import gql from 'graphql-tag'
import { useQuery } from '@vue/apollo-composable'


const MOVIE_QUERY = gql`query movies {
  allFilms {
    films {
      director
      title
      releaseDate
    }
  }
}`;

const data= useQuery(MOVIE_QUERY);

</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

.column {
  float: left;
  width: 50%;
}

input[type="button"]
{
    margin:20px;
    height: 50px;
    width: 200px;
}

/* Clear floats after the columns */
.row:after {
  content: "";
  display: table;
  clear: both;
}

.result{
  height:500px;
  width: 50%;
}
</style>
