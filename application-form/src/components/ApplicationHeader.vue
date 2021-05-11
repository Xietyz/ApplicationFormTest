<template>
  <div class="form-header">
    <h1>{{ msg }}</h1>
    <h2>header</h2>
  </div>
</template>

<script>
export default {
  name: 'AppHeader',
  props: {
    msg: String
  },
  data() {
      return{
          //data
      }
  }
}
</script>

<style scoped>

</style>