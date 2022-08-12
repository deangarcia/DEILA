import { getStoreAccessors } from 'typesafe-vuex';
import { State } from '../state';
import { SentimentState } from "./state";
import { ISentimentAnalysis } from "@/interfaces/sentiment";

export const mutations = {
    setSentiment(state: SentimentState, payload: ISentimentAnalysis) {
        state.result = payload;
    },
};

const { commit } = getStoreAccessors<SentimentState, State>("");

export const commitSetSentiment = commit(mutations.setSentiment);