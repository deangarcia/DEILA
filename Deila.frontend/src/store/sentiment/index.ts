import { mutations } from './mutations';
import { getters } from './getters';
import { actions } from './actions';
import { SentimentState } from './state';

const defaultState: SentimentState = {
    result: {negative: 0, positive: 0},
};

export const sentimentModule = {
    state: defaultState,
    mutations,
    actions,
    getters,
};
