<script setup lang="ts">
import { ref } from "vue";
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
const gridItems = ref<PokemonResult[]>([]);
const currentPage = ref<number>(1);
const totalPages = ref<number>(10);
const limit = ref<number>(10);

async function getData(){
  console.log('loading')
  var response = await axios.get<PokemonResponse>("https://pokeapi.co/api/v2/pokemon?limit="+ limit.value +"&offset=0")
  gridItems.value = response.data.results;
}


async  function goToPage(pageNumber:number){
  console.log("fetching next page : " + pageNumber);
  const offset = pageNumber * limit.value;
  var response = await axios.get<PokemonResponse>("https://pokeapi.co/api/v2/pokemon?limit="+ limit.value +"&offset=" + offset)
  gridItems.value = response.data.results;
  currentPage.value = pageNumber;
}
</script>

<template>
  <div class="container mt-4">
    <header class="mb-4">
      <h1>Pokémon Data Grid</h1>
    </header>
    <div class="mb-3">
      <button class="btn btn-primary" @click="getData">Load Data</button>
    </div>
    <div class="table-responsive">
      <table class="table table-striped">
        <thead>
          <tr>
            <th>Name</th>
            <th>URL</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in gridItems" :key="index">
            <td>{{ item.name }}</td>
            <td><a :href="item.url" target="_blank">{{ item.url }}</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <nav>
      <ul class="pagination justify-content-center">
        <li class="page-item" :class="{ disabled: currentPage === 1 }">
          <a class="page-link" @click="goToPage(currentPage - 1)">Previous</a>
        </li>
        <li
          class="page-item"
          v-for="page in totalPages"
          :key="page"
          :class="{ active: currentPage === page }"
        >
          <a class="page-link" @click="goToPage(page)">{{ page }}</a>
        </li>
        <li class="page-item" :class="{ disabled: currentPage === totalPages }">
          <a class="page-link"  @click="goToPage(currentPage + 1)">Next</a>
        </li>
      </ul>
    </nav>
  </div>
</template>
