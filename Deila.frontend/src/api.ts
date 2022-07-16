import axios from 'axios';
import { apiUrl } from '@/env';

function authHeaders(token: string) {
    return {
        headers: {
            Authorization: `Bearer ${token}`,
        },
    };
}


export const api = {

};
