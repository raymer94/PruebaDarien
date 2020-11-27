import VueRouter from 'vue-router';
import EmpList from '../components/EmpList.vue'
import EmpRegister from '../components/EmpRegister.vue'

const routes = [
  { path: '/', name: "EmpList", component: EmpList },
  { path: '/register', name: "EmpRegister", component: EmpRegister }
];

const router = new VueRouter({
  mode: 'history',
  base: __dirname,
  routes
});

export default router;