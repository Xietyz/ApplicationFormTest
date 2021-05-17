<template>
  <div id="form-header">
    <h1 class="headers">{{ msg }}</h1>
    <h2 class="headers">State: {{this.stateDesc}} ({{ this.stateNo }})</h2>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "AppHeader",
  props: {
    msg: String,
  },
  computed: mapState({
    //when state.count is changed, trigger dom updates
    //mapstate shorthand for return this.$store.state.count
    stateNo: (state) => state.count.stateNo,
    stateDesc: (state) => state.count.stateDesc,
  }),
};
</script>

<style scoped>
.headers {
  text-align: center;
}
</style>