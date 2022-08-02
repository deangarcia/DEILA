import './component-hooks';
import '@babel/polyfill';
import './plugins/vuetify';
import './plugins/vee-validate';
import Vue from 'vue'
import App from './App.vue'
import router from './router';
import store from '@/store';
import Vuetify from 'vuetify';
import 'vuetify/dist/vuetify.min.css';
import './registerServiceWorker';
import './plugins/vee-validate';
import '@mdi/font/css/materialdesignicons.css';

const vuetify = new Vuetify()
Vue.config.productionTip = false
Vue.use(Vuetify)

new Vue({
    router,
    store,
    vuetify,
    render: h => h(App),
}).$mount('#app')
