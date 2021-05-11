<template>
  <form @submit.prevent class="form-fields">
    <span>Organisation name: </span>
    <input class="input" v-model="inputOrgName" />
    <p></p>
    <span>Full name: </span>
    <input class="input" v-model="inputName" />
    <p></p>
    <span>Email: </span>
    <input class="input" v-model="inputEmail" />
    <p></p>
    <span>Position: </span>
    <input class="input" v-model="inputPosition" />
    <p></p>
    <span>Website: </span>
    <input class="input" v-model="inputWebsite" />
    <p></p>
    <span>Organisation type: </span>
    <select class="input" style="width: 183px" v-model="selectOrg">
      <option>{{ optionOrg1 }}</option>
      <option>{{ optionOrg2 }}</option>
      <option>{{ optionOrg3 }}</option>
    </select>
    <p></p>
    <div v-if="selectOrg == optionOrg1">
      <span>FCA Number: </span>
      <input class="input" v-model="inputFCANo" />
      <p></p>
    </div>
    <div v-else-if="selectOrg == optionOrg2">
      <span>FCA Number of lead: </span>
      <input class="input" v-model="inputFCANo" />
      <p></p>
      <span>Your membership number: </span>
      <input class="input" v-model="inputMembershipNo" />
      <p></p>
    </div>
    <span>Phone number: </span>
    <input class="input" v-model="inputPhoneNo" />
    <p></p>
    <span>Address: </span>
    <input class="input" v-model="inputAddress" />
    <p></p>
    <span>Insurer: </span>
    <input class="input" v-model="inputInsurer" />
    <p></p>
    <span>Policy number: </span>
    <input class="input" v-model="inputPolicyNo" />
    <p></p>
    <button type="button" @click="SubmitClick()">Submit</button>
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
    SubmitClick() {
      //submit button click handler
      axios.post("https://localhost:44331/api/test/user", {
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
        alert(this.inputName);
        //axios.get("https://localhost:44331/api/test/user");
        //.then((response) => console.log(response.data));
      } else {
        alert("please do x lol");
      }
      //route to confirm page
      console.log("bout to head out");
      this.$router.push({ path: 'confirmation'});
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
    };
  },
};
</script>

<style scoped>
span {
  text-align: right;
  padding-right: 20px;
  display: inline-block;
  min-width: 200px;
}
.input {
  display: inline-block;
  width: 175px;
}
</style>