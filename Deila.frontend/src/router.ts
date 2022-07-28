import Vue from 'vue';
import Router from 'vue-router';
import RouterComponent from './components/RouterComponent.vue';

Vue.use(Router);

export default new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    routes: [
        {
            path: '/',
            name: "root",
            component: () => import(/* webpackChunkName: "start" */ './views/main/Start.vue'),
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
                        {
                            path: 'basis',
                            component: RouterComponent,
                            redirect: 'basis/basis',
                            children: [
                                {
                                    path: 'basis',
                                    name: 'basis',
                                    component: () =>
                                        import(/* webpackChunkName: "main-article" */ './views/main/basis/Basis.vue'),
                                },
                                {
                                    path: 'basis/add',
                                    name: 'basis-add',
                                    component: () =>
                                        import('@/views/main/basis/BasisAdd.vue'),
                                },
                                {
                                    path: 'basis/edit',
                                    name: 'basis-edit',
                                    component: () =>
                                        import('@/views/main/basis/BasisEdit.vue'),
                                },
                            ],
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
