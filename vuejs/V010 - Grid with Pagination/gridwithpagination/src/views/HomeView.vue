<script setup lang="ts">
import { reactive } from "vue";
import axios from "axios";

// Interface for each Pokémon result
interface PokemonResult {
  name: string; // Name of the Pokémon
  url: string;  // URL to the Pokémon details
}

// Main interface for the response from the Pokémon API
interface PokemonResponse {
  count: number;                // Total number of Pokémon available
  next: string | null;          // URL for the next set of results (if available)
  previous: string | null;      // URL for the previous set of results (if available)
  results: PokemonResult[];     // Array of Pokémon results
}
const gridItems = reactive<Array<PokemonResult>>([]);

async function getData(){
  console.log('loading')
  var response = await axios.get<PokemonResponse>("https://pokeapi.co/api/v2/pokemon?limit=10&offset=0")
 gridItems.value = response.data.results;
}
</script>

<template>
  <div class="container">
    <header class="header">
      <h1>My Vue App</h1>
    </header>
    <div class="button-container">
      <button @click="getData()">Load Data</button>
      <button >Button 2</button>
      {{ gridItems.count }}
    </div>
    <div class="grid">
      <div class="grid-item" v-for="item in gridItems.value" :key="item.id">
        Name = {{ item.name }}
      </div>
    </div>
  </div>
  </template>
