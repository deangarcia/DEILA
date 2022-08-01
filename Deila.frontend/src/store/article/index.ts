import { actions } from './actions';
import { getters } from './getters';
import { mutations } from './mutations';
import { ArticleState } from './state';

const defaultState: ArticleState = {
    articles: [],
};

export const articleModule = {
    state: defaultState,
    mutations,
    actions,
    getters,
};
