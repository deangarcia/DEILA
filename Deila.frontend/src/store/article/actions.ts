import { api } from '@/api';
import {
    IArticleCreate,
    IArticleUpdate,
} from '@/interfaces/article/index';
import { dispatchCheckApiError } from '@/store/main/actions';
import {
    commitAddNotification,
    commitRemoveNotification,
} from '@/store/main/mutations';
import { State } from '@/store/state';
import { AxiosError } from 'axios';
import { getStoreAccessors } from 'typesafe-vuex';
import { ActionContext } from 'vuex';
import {
    commitDeleteArticle,
    commitSetArticles,
    commitSetArticle,
    commitUpdateArticle,
} from './mutations';
import { ArticleState } from './state';

type MainContext= ActionContext<ArticleState, State>;

export const actions = {
    async actionGetArticles(context: MainContext) {
        try {
            const response = await api.getMyArticles();
            if (response) {
                commitSetArticles(context, response.data);
            }
        } catch (error) {
            const axiosError: AxiosError = error as AxiosError;
            await dispatchCheckApiError(context, axiosError);
        }
    },
    async actionCreateArticle(
        context: MainContext,
        payload: { article: IArticleCreate },
    ) {
        try {
            const loadingNotification = {
                content: 'saving',
                showProgress: true,
            };
            commitAddNotification(context, loadingNotification);
            const response = (
                await Promise.all([
                    api.createArticle(
                        payload.article,
                    ),
                    await new Promise<void>((resolve, reject) =>
                        setTimeout(() => resolve(), 500),
                    ),
                ])
            )[0];
            commitSetArticle(context, response.data);
            commitRemoveNotification(context, loadingNotification);
            commitAddNotification(context, {
                content: 'Article successfully created',
                color: 'success',
            });
        } catch (error) {
            const axiosError: AxiosError = error as AxiosError;
            await dispatchCheckApiError(context, axiosError);
        }
    },
    async actionUpdateArticle(
        context: MainContext,
        payload: { id: number; article: IArticleUpdate },
    ) {
        try {
            const loadingNotification = {
                content: 'saving',
                showProgress: true,
            };
            commitAddNotification(context, loadingNotification);
            const response = (
                await Promise.all([
                    api.updateArticle(
                        payload.id,
                        payload.article,
                    ),
                    await new Promise<void>((resolve, reject) =>
                        setTimeout(() => resolve(), 500),
                    ),
                ])
            )[0];
            commitUpdateArticle(context, response.data);
            commitRemoveNotification(context, loadingNotification);
            commitAddNotification(context, {
                content: 'Article successfully updated',
                color: 'success',
            });
        } catch (error) {
            const axiosError: AxiosError = error as AxiosError;
            await dispatchCheckApiError(context, axiosError);
        }
    },
    async actionDeleteArticle(context: MainContext, payload: { id: number }) {
        try {
            const loadingNotification = {
                content: 'deleting',
                showProgress: true,
            };
            commitAddNotification(context, loadingNotification);
            const response = await api.deleteArticle(
                payload.id,
            );
            if (response) {
                commitDeleteArticle(context, response.data);
            }
            commitRemoveNotification(context, loadingNotification);
            commitAddNotification(context, {
                content: 'Article successfully deleted',
                color: 'success',
            });
        } catch (error) {
            const axiosError: AxiosError = error as AxiosError;
            await dispatchCheckApiError(context, axiosError);
        }
    },
};

const { dispatch } = getStoreAccessors<ArticleState, State>('');

export const dispatchGetArticles = dispatch(actions.actionGetArticles);
export const dispatchCreateArticle = dispatch(actions.actionCreateArticle);
export const dispatchUpdateArticle = dispatch(actions.actionUpdateArticle);
export const dispatchDeleteArticle = dispatch(actions.actionDeleteArticle);
