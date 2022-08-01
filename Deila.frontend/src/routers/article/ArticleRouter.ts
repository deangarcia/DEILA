const ArticleRouter = [
    {
        path: 'article/article_view',
        name: 'main-article',
        component: () =>
            import('@/views/main/article/Article.vue'),
    },
];

export default ArticleRouter;
