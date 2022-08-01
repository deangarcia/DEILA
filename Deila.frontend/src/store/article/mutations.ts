import { IArticle } from '@/interfaces/article/index';
import { State } from '@/store/state';
import { getStoreAccessors } from 'typesafe-vuex';
import { ArticleState } from './state';

export const mutations = {
    setArticles(state: ArticleState, payload: IArticle[]) {
        state.articles = payload;
    },
    setArticle(state: ArticleState, payload: IArticle) {
        const otherArticles = state.articles.filter(
            (item) => item.id !== payload.id,
        );
        state.articles = otherArticles;
        state.articles.push(payload);
    },
    updateArticle(state: ArticleState, payload: IArticle) {
        const otherArticles = state.articles.filter(
            (item) => item.id !== payload.id,
        );
        otherArticles.push(payload);
        state.articles = otherArticles;
    },
    deleteArticle(state: ArticleState, payload: IArticle) {
        const otherArticles = state.articles.filter(
            (item) => item.id !== payload.id,
        );
        state.articles = otherArticles;
    },
};

const { commit } = getStoreAccessors<ArticleState, State>('');

export const commitSetArticles = commit(mutations.setArticles);
export const commitSetArticle = commit(mutations.setArticle);
export const commitUpdateArticle = commit(mutations.setArticle);
export const commitDeleteArticle = commit(mutations.deleteArticle);
