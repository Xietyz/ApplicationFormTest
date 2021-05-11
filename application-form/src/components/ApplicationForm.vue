<template>
  <div class="main-form">
    <application-header msg="Registration" />
    <br />
    <application-fields/>
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
    return {
    };
  },
};
</script>

<style scoped>
.form-header2 {
  font-weight: bold;
  text-align: left;
}
.form-header1 {
  text-align: left;
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
