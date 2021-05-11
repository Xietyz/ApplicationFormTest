import Vue from 'vue'
import VueRouter from 'vue-router'
import Confirmation from '../views/Confirmation.vue'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/confirmation',
    name: 'Confirmation',
    component: Confirmation,

    //component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  },
]

const router = new VueRouter({
  routes
})

export default router
