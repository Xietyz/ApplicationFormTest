<template>
  <div class="main-form">
    <div class="container">
      <div
        id="form-comp"
        class="row"
        style="background-color: white; border: 3px solid rgba(0, 0, 0, 0.1)"
      >
        <div class="col">
          <application-fields />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ApplicationHeader from "./ApplicationHeader.vue";
import ApplicationFields from "./ApplicationFields.vue";

export default {
  name: "AppForm",
  components: {
    ApplicationHeader,
    ApplicationFields,
  },
  data() {
    return {};
  },
};
</script>

<style scoped>
.logo-header {
  margin-bottom: 2%;
}
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
