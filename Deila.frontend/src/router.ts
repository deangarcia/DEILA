import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            name: "root",
            component: () => import(/* webpackChunkName: "start" */ './views/main/Main.vue'),
            children: [
                {
                    path: 'main',
                    name: "main",
                    component: () => import(/* webpackChunkName: "main" */ './views/main/Main.vue'),
                    children: [
                        {
                            path: 'dashboard',
                            name: "main-dashboard",
                            component: () => import(/* webpackChunkName: "main-dashboard" */ './views/main/Dashboard.vue'),
                        },
                    ],
                },
            ]
        },
        {
            path: '/*', redirect: '/',
        },
    ],
});
