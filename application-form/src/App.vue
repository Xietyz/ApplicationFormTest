<template>
  <div style="background-color: #eee; height: auto; min-height: 1475px">
    <div class="container">
      <div class="row top-row">
        <div class="col-md-1">s {{ this.$store.state.count.stateNo }}</div>
        <div class="col">column2.</div>
      </div>
      <div class="row logo-header" style="margin-top: 50px">
        <div class="col">
          <img
            alt="Vue logo"
            src="./assets/logo.png"
            style="display: block; margin-left: auto; margin-right: auto"
          />
          <application-header msg="Registration" />
        </div>
      </div>
    </div>
    <div id="app">
      <router-view />
    </div>
  </div>
</template>

<script>
import ApplicationHeader from "./components/ApplicationHeader.vue";
import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
  state: {
    count: {stateNo: 0, stateDesc: "Registration"}
  },
  mutations: {
    increment(state, val) {
      state.count.stateNo = val;
      state.count.stateDesc = "Registration";
      console.log(store.state.count);
    },
    decrement(state, val) {
      state.count.stateNo = val;
      state.count.stateDesc = "Registered";
      console.log(store.state.count);
    },
  },
  actions: {
    incrementAct(context) {
      context.commit("increment", 1);
    },
    decrementAct(context) {
      context.commit("decrement", 0);
    },
  },
  getters: {
      //  getTodoById: (state) => (id) => {
      //      return state.todos.find(todo => todo.id === id)
      //  } this accepts id as a parameter in store.getters.getTodoById(val)
      //importing {mapGetters} from vuex lets you use:
      //       computed: mapGetters([
      //     'doneTodos', 'doneTodosCount', 'getTodoById'
      // ]) to easily give children access to getters
  },
});

export default {
  name: "App",
  store: store,
  components: {
    ApplicationHeader,
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
.top-row {
  background-color: green;
  color: rgb(255, 255, 255);
}
</style>