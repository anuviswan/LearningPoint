<template>
  <div>
    <label>
      Name
      <input type="text" v-model="input" name="name" />
    </label>
    <!-- <ErrorDisplay :errors="errors" /> -->
  </div>
</template>

<script>
import useInputValidator from "../features/useInputValidator";
import { minLength } from "../features/validators";
export default {
  name: "InputName",
  setup(props, { emit }) {
    const { input, errors } = useInputValidator(
      props.value,
      [minLength(3)],
      (value) => emit("input", value.value)
    );

    return {
      input,
      errors,
    };
  },
};
</script>

<style></style>
