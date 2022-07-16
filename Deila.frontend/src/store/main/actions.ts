import { api } from '@/api';
import router from '@/router';
import { AxiosError } from 'axios';
import { getStoreAccessors } from 'typesafe-vuex';
import { ActionContext } from 'vuex';
import { State } from '../state';
import {
    commitAddNotification,
    commitRemoveNotification,
} from './mutations';
import { AppNotification, MainState } from './state';

type MainContext = ActionContext<MainState, State>;

export const actions = {
    async removeNotification(context: MainContext, payload: { notification: AppNotification, timeout: number }) {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                commitRemoveNotification(context, payload.notification);
                resolve(true);
            }, payload.timeout);
        });
    },
    async actionCheckApiError(context: MainContext, payload: any) {
        try {
            if (payload.response!.status === 401) {
                commitAddNotification(context, {
                    color: "error",
                    content: "401 Error.",
                });
            }
        } catch (error) {
            commitAddNotification(context, {
                color: "error",
                content: "Failed check API Error.",
            });
        }
    },
};

const { dispatch } = getStoreAccessors<MainState | any, State>('');

export const dispatchRemoveNotification = dispatch(actions.removeNotification);
export const dispatchCheckApiError = dispatch(actions.actionCheckApiError);