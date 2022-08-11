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
                                        import(/* webpackChunkName: "main-basis" */ './views/main/basis/Basis.vue'),
                                },
                            ],
                        },
                        {
                            path: 'article',
                            component: RouterComponent,
                            redirect: 'article/article',
                            children: [
                              {
                                path: 'article',
                                name: 'article',
                                component: () =>
                                    import(/* webpackChunkName: "main-article" */ './views/main/article/Article.vue'),
                              },
                              {
                                path: 'article/add',
                                name: 'article-add',
                                component: () =>
                                    import('@/views/main/article/ArticleAdd.vue'),
                              },
                              {
                                path: 'article/edit',
                                name: 'article-edit',
                                component: () =>
                                    import('@/views/main/article/ArticleEdit.vue'),
                              },
                            ],
                        },
                        {
                            path: 'sentiment',
                            component: RouterComponent,
                            redirect: 'sentiment/sentiment',
                            children: [
                              {
                                path: 'sentiment',
                                name: 'sentiment',
                                component: () =>
                                    import(/* webpackChunkName: "main-sentiment" */ './views/main/sentiment/SentimentAnalysis.vue'),
                              },
                              {
                                path: 'sentiment/report',
                                name: 'sentiment-report',
                                component: () =>
                                    import('@/views/main/sentiment/SentimentAnalysisReport.vue'),
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
