<template>
  <div class="container">
    <div class="row">
      <div
        class="col"
        style="background-color: white; border: 3px solid rgba(0, 0, 0, 0.1)"
      >
        <application-fields />
      </div>
    </div>
  </div>
</template>

<script>
import ApplicationFields from "../components/ApplicationFields.vue";
export default {
  name: "Home",
  components: {
    ApplicationFields,
  },
};
</script>