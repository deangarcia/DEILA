import { mutations } from './mutations';
import { getters } from './getters';
import { actions } from './actions';
import { BasisState } from './state';

const defaultState: BasisState = {
    basiss: [],
};

export const basisModule = {
    state: defaultState,
    mutations,
    actions,
    getters,
};
