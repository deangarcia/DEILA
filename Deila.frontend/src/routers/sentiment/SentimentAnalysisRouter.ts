const SentimentAnalysisRouter = [
    {
        path: 'sentiment/sentiment_view',
        name: 'main-sentiment',
        component: () =>
            import('@/views/main/sentiment/SentimentAnalysisManager.vue'),
    },
];

export default SentimentAnalysisRouter;
