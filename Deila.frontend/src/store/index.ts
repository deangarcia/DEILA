import Vue from 'vue';
import Vuex, { StoreOptions } from 'vuex';

import { mainModule } from './main';
import { basisModule } from './basis';
import { articleModule } from './article';
import { State } from './state';
import { sentimentModule } from './sentiment';

Vue.use(Vuex);

const storeOptions: StoreOptions<State> = {
    modules: {
        main: mainModule,
        basis: basisModule,
        article: articleModule,
        sentiment: sentimentModule,
    },
};

export const store = new Vuex.Store<State>(storeOptions);

export default store;
