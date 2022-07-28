import Vue from 'vue';
import Vuex, { StoreOptions } from 'vuex';

import { mainModule } from './main';
import { basisModule } from './basis';
import { State } from './state';

Vue.use(Vuex);

const storeOptions: StoreOptions<State> = {
    modules: {
        main: mainModule,
        basis: basisModule,
    },
};

export const store = new Vuex.Store<State>(storeOptions);

export default store;
