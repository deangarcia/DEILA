import Vue from 'vue';
import Vuex, { StoreOptions } from 'vuex';

import { mainModule } from './main';
import { basisModule } from './basis';
import { articleModule } from './article';
import { State } from './state';

Vue.use(Vuex);

const storeOptions: StoreOptions<State> = {
    modules: {
        main: mainModule,
        basis: basisModule,
        article: articleModule,
    },
};

export const store = new Vuex.Store<State>(storeOptions);

export default store;
