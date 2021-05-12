<template>
  <form @submit.prevent class="form-fields">
    <div class="container">
      <div class="row header-row">
        <div class="col-3"><h4 class="header-number">1:</h4></div>
        <div class="col-9"><h5 class="input-header">Personal details</h5></div>
      </div>

      <div class="row justify-content-center">
        <div class="col">
          <label style="text-align: left; float: right">
            Full name
            <input class="form-control" v-model="inputName" />
          </label>
        </div>
        <div class="col" style="text-align: left">
          <label>
            Phone number
            <input class="form-control" v-model="inputPhoneNo" />
          </label>
        </div>
      </div>

      <div class="row justify-content-center" style="text-align: right">
        <div class="col">
          <label style="text-align: left">
            Email
            <input class="form-control" v-model="inputEmail" />
          </label>
        </div>
        <div class="col" style="text-align: left"></div>
      </div>

      <div class="row header-row">
        <div class="col-3"><h4 class="header-number">2:</h4></div>
        <div class="col-9">
          <h5 class="input-header">Organisation details</h5>
        </div>
      </div>

      <div class="row justify-content-center">
        <div class="col">
          <label style="text-align: left; float: right">
            Organisation name
            <input class="form-control" v-model="inputOrgName" />
          </label>
        </div>
        <div class="col">
          <label style="text-align: left; float: left">
            Organisation type
            <select
              class="form-control"
              v-model="selectOrg"
              style="height: 38px"
            >
              <option>{{ optionOrg1 }}</option>
              <option>{{ optionOrg2 }}</option>
              <option>{{ optionOrg3 }}</option>
            </select>
          </label>
        </div>
      </div>

      <div class="row justify-content-center">
        <div class="col">
          <label style="float: right; text-align: left">
            Website (opt.)
            <input class="form-control" v-model="inputWebsite" />
          </label>
        </div>
        <div class="col" style="text-align: left; float: left">
          <div
            class="col"
            v-if="selectOrg == optionOrg1 || selectOrg == optionOrg2"
          >
            <label>
              FCA No.
              <input class="form-control" v-model="inputFCANo" />
            </label>
          </div>
        </div>
      </div>

      <div class="row justify-content-center">
        <div class="col">
          <label style="float: right; text-align: left">
            Position
            <input class="form-control" v-model="inputPosition" />
          </label>
        </div>
        <div class="col" style="text-align: left">
          <div class="col" v-if="selectOrg == optionOrg2">
            <label>
              Membership No.
              <input class="form-control" v-model="inputMembershipNo" />
            </label>
          </div>
        </div>
      </div>

      <div class="row justify-content-center">
        <div class="col">
          <label style="float: right; text-align: left">
            Address
            <input class="form-control" v-model="inputAddress" />
          </label>
        </div>
        <div class="col" style="text-align: left"></div>
      </div>

      <div class="row header-row">
        <div class="col-3"><h4 class="header-number">3:</h4></div>
        <div class="col-9">
          <h5 class="input-header">Insurer indemnity details</h5>
        </div>
      </div>

      <div class="row justify-content-center">
        <div class="col">
          <label style="float: right; text-align: left">
            Insurer
            <input class="form-control" v-model="inputInsurer" />
          </label>
        </div>
        <div class="col" style="text-align: left"></div>
      </div>
      <div class="row justify-content-center">
        <div class="col">
          <label style="float: right; text-align: left">
            Policy No.
            <input class="form-control" v-model="inputPolicyNo" />
          </label>
        </div>
        <div class="col" style="text-align: left"></div>
      </div>

      <div class="row input-row" style="margin-top: 20px">
        <div class="col">
          <button
            class="button"
            type="button"
            @click="SubmitClick()"
            style="margin-bottom: 15px"
          >
            Submit
          </button>
        </div>
      </div>
      <!--  -->
    </div>
  </form>
</template>

<script>
import Vue from "vue";
import axios from "axios";
import VueRouter from "vue-router";
Vue.use(VueRouter);

export default {
  name: "AppFields",
  methods: {
    async SubmitClick() {
      //submit button click handler
      await axios.post("https://localhost:44331/api/test/user", {
        orgname: this.inputOrgName,
        name: this.inputName,
        email: this.inputEmail,
        position: this.inputPosition,
        website: this.inputWebsite,
        fcano: this.inputFCANo,
        membershipno: this.inputMembershipNo,
        phoneno: this.inputPhoneNo,
        address: this.inputAddress,
        insurer: this.inputInsurer,
        policyno: this.inputPolicyNo,
      });
      if (this.inputName !== "") {
        //conditionals
        //axios.get("https://localhost:44331/api/test/user");
        //.then((response) => console.log(response.data));
        //route to confirm page
        this.$router.push({ path: "confirmation" });
      }
    },
  },
  data() {
    return {
      //dat
      inputOrgName: "",
      inputName: "",
      inputEmail: "",
      inputPosition: "",
      inputWebsite: "", //optional
      inputMembershipNo: "",
      inputPhoneNo: "",
      inputFCANo: "",
      inputAddress: "",
      //professional insurance details
      inputInsurer: "",
      inputPolicyNo: "",
      selectOrg: "",
      optionOrg1: "Directly regulated",
      optionOrg2: "Authorised representative",
      optionOrg3: "Not regulated",

      //bootstrap classes
      rowInputClass: "row input-row justify-content-center",
      inputLabelRowClass: "col-3",
      inputFieldRowClass: "col-3",
    };
  },
};
//css:
//display: inline-block;
</script>

<style scoped>
label {
  margin-top: 10px;
  margin-bottom: 5px;
}
.input-header {
  text-align: left;
  position: absolute;
  top: 50%;
  -ms-transform: translateY(-50%);
  transform: translateY(-50%);
}
.header-number {
  text-align: right;
  margin-bottom: 0px;
}
.input-row {
  margin-top: 15px;
}
.header-row {
  padding-top: 10px;
  padding-bottom: 10px;
  border-style: solid;
  border-width: 0px;
  border-bottom-width: 1px;
  border-bottom-color: rgb(218, 217, 217);
}
.form-control {
  width: 100%;
}

.input {
  width: 175px;
  float: left;
}

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