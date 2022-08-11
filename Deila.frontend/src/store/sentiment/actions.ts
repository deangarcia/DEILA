import { api } from '@/api';
import { getStoreAccessors } from 'typesafe-vuex';
import { ActionContext } from 'vuex';
import { State } from '../state';
import { dispatchCheckApiError } from "@/store/main/actions";
import {
    commitSetSentiment,
} from './mutations';
import { SentimentState } from './state';

type MainContext = ActionContext<SentimentState, State>;

export const actions = {
    async actionGetSentiment(context: MainContext, text: string) {
        try {
            const response = await api.getSentiment(
                text
            );
            if (response) {
                commitSetSentiment(context, response.data);
            }
        } catch (error) {
            await dispatchCheckApiError(context, error);
        }
    },
};

const { dispatch } = getStoreAccessors<SentimentState | any, State>('');


export const dispatchGetSentiment = dispatch(actions.actionGetSentiment);