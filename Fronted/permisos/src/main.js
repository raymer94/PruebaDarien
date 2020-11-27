import Vue from 'vue'
import VueRouter from 'vue-router';
import App from './App.vue'
import router from './router'
import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import VueSweetalert2 from 'vue-sweetalert2';


Vue.config.productionTip = false
Vue.use(VueSweetalert2);
Vue.use(VueRouter);


new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
