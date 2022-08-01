import { State } from '@/store/state';
import { getStoreAccessors } from 'typesafe-vuex';
import { ArticleState } from './state';

export const getters = {
    articles: (state: ArticleState) => state.articles,
    ArticlesOne: (state: ArticleState) => (articleId: number) => {
        const filtered = state.articles.filter((i) => i.id === articleId);
        if (filtered.length > 0) {
            return { ...filtered[0] };
        }
    },
};

const { read } = getStoreAccessors<ArticleState, State>('');

export const readArticles = read(getters.articles);
export const readArticlesOne = read(getters.ArticlesOne);
