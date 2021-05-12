<template>
  <div style="background-color: #eee; height: auto; min-height: 1300px;">
    <div class="container">
      <div class="row top-row">
        <div class="col-md-1">column1</div>
        <div class="col">column2.</div>
      </div>
    </div>
    <div id="app">
      <router-view />
    </div>
  </div>
</template>

<script>
//import ApplicationForm from './components/ApplicationForm.vue'
export default {
  name: "App",
  components: {
    //ApplicationForm
  },
};
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
.top-row{
  background-color: green;
  color: rgb(255, 255, 255);
}
</style>
