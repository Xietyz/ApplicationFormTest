<template>
  <div class="topdiv">
    <div class="row input-row" style="margin-top: 20px">
      <div class="col">
        <h1>Registered</h1>
      </div>
    </div>
    <div class="row input-row" style="margin-top: 20px">
      <div class="col"></div>
    </div>
    <div class="row input-row" style="margin-top: 20px">
      <div class="col">
        <button
          class="button"
          type="button"
          @click="BackClick()"
          style="margin-bottom: 15px"
        >
          Back
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";
export default {
  name: "RegisterConfirm",
  data() {
    return {
      //data
    };
  },
  methods: {
    BackClick() {
      this.$store.dispatch("decrementAct");
      this.$router.push({ path: "/" });
    },
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
.button {
  appearance: none;
  outline: 0;
  background-color: #2e946a;
  border: 0;
  padding: 10px 15px;
  color: #ffffff;
  border-radius: 3px;
  width: 250px;
  cursor: pointer;
  font-size: 18px;
  transition-duration: 0.25s;
}
.button:hover {
  background-color: rgb(83, 189, 109);
}
</style>