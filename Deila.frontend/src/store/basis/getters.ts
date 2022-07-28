import { BasisState } from './state';
import { getStoreAccessors } from 'typesafe-vuex';
import { State } from '../state';

export const getters = {
    basiss: (state: BasisState) => state.basiss,
};

const { read } = getStoreAccessors<BasisState, State>('');
export const readBasiss = read(getters.basiss);

