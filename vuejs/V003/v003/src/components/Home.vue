<template>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <h1>Computed Vs Watchers Vs Methods</h1>
      </div>
    </div>
    <div class="row">
      <div class="col-12 border py-3 bg-light">
        Inputs :
        <input v-model="firstName" placeholder="First Name" class="mx-2" />
        <input v-model="lastName" placeholder="Last Name" class="mx-2" />
        <input v-model="age" placeholder="Age" class="mx-2" />
      </div>
    </div>
    <div class="row g-2">
      <div class="col-4 border">
        <div><b>Computed</b></div>
        <div>FirstName :{{ firstName }}</div>
        <div>LastName :{{ lastName }}</div>
        <div>Computed 1:{{ ComputedFullName }}</div>
        <div>Computed 2:{{ ComputedFullName }}</div>
        <div>Computed Age:{{ ComputedAge }}</div>
      </div>
      <div class="col-4 border">
        <div class="col-4 border">
          <div><b>Watchers</b></div>
          <div>FirstName :{{ firstName }}</div>
          <div>LastName :{{ lastName }}</div>
          <div>Computed 1:{{ ComputedFullName }}</div>
          <div>Computed 2:{{ ComputedFullName }}</div>
        </div>
      </div>
      <div class="col-4 border">
        <div><b>Methods</b></div>
        <div>FirstName :{{ firstName }}</div>
        <div>LastName :{{ lastName }}</div>
        <div>Computed 1:{{ GetFullName() }}</div>
        <div>Computed 2:{{ GetFullName() }}</div>
        <div>Computed Age:{{ GetAge() }}</div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Home",
  data() {
    return {
      firstName: "",
      lastName: "",
      age: 0,
    };
  },
  computed: {
    ComputedFullName: function() {
      console.log("Calling Computed Full Method");
      return this.firstName.concat(this.lastName);
    },
    ComputedAge: function() {
      console.log("Calling Computed Age Method");
      return this.age + "Yrs";
    },
  },
  methods: {
    GetFullName() {
      console.log("Calling FullName Method");
      return this.firstName.concat(this.lastName);
    },
    GetAge() {
      console.log("Call Age Method");
      return this.age + "Yrs";
    },
  },
};
</script>

<style></style>
