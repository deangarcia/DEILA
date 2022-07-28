import axios from 'axios';
import { apiUrl } from '@/env';
import { IBasis, IBasisUpdate, IBasisCreate } from './interfaces/basis';

function authHeaders(token: string) {
    return {
        headers: {
            Authorization: `Bearer ${token}`,
        },
    };
}


export const api = {

    async getBasiss() {
        return axios.get<IBasis[]>(`${apiUrl}/api/basiss/`);
    },

};
