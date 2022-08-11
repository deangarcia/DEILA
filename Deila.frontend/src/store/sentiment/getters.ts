import { SentimentState } from './state';
import { getStoreAccessors } from 'typesafe-vuex';
import { State } from '../state';

export const getters = {
    sentiment: (state: SentimentState) => state.result,
};

const { read } = getStoreAccessors<SentimentState, State>('');
export const readSentiment = read(getters.sentiment);

