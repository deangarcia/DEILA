import axios from 'axios';
import { apiUrl } from '@/env';
import { IBasis, IBasisUpdate, IBasisCreate } from './interfaces/basis';
import { IArticle, IArticleCreate, IArticleUpdate } from './interfaces/article';

export const api = {
    ////////////////////////////////// Article //////////////////////////////////////////////
    async getMyArticles() {
        return axios.get<IArticle[]>(`${apiUrl}/api/articles/`);
    },
    async createArticle(data: IArticleCreate) {
        return axios.post(`${apiUrl}/api/articles/`, data);
    },
    async getArticle(articleId: number) {
        return axios.get<IArticle>(`${apiUrl}/api/articles/${articleId}`);
    },
    async updateArticle(articleId: number, data: IArticleUpdate) 
    {
        return axios.put(`${apiUrl}/api/articles/${articleId}`, data);
    },
    async deleteArticle(articleId: number) {
        return axios.delete(`${apiUrl}/api/articles/${articleId}`);
    },
    ////////////////////////////////// Basis //////////////////////////////////////////////
    async getBasiss() {
        return axios.get<IBasis[]>(`${apiUrl}/api/basiss/`);
    },

};
