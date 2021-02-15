import { createRouter, createWebHashHistory } from 'vue-router'
import Home from '../components/Home'
import Add from "../components/Add"
import About from "../components/About"
const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/add',
    name: 'Add',
    component: Add
  },
  {
    path: '/about',
    name: 'About',
    component: About
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
