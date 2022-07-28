import { getStoreAccessors } from 'typesafe-vuex';
import { State } from '../state';
import { BasisState } from "./state";
import { IBasis } from "@/interfaces/basis";

export const mutations = {
    setBasiss(state: BasisState, payload: IBasis[]) {
        state.basiss = payload;
    },
};

const { commit } = getStoreAccessors<BasisState, State>("");

export const commitSetBasiss = commit(mutations.setBasiss);