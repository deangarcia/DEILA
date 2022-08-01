import { api } from '@/api';
import { getStoreAccessors } from 'typesafe-vuex';
import { ActionContext } from 'vuex';
import { State } from '../state';
import { dispatchCheckApiError } from "@/store/main/actions";
import {
    commitSetBasiss,
} from './mutations';
import { BasisState } from './state';

type MainContext = ActionContext<BasisState, State>;

export const actions = {
    async actionGetBasiss(context: MainContext) {
        try {
            const response = await api.getBasiss();
            if (response) {
                commitSetBasiss(context, response.data);
            }
        } catch (error) {
            await dispatchCheckApiError(context, error);
        }
    },
};

const { dispatch } = getStoreAccessors<BasisState | any, State>('');


export const dispatchGetBasiss = dispatch(actions.actionGetBasiss);