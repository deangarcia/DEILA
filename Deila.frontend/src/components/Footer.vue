<template>
        <v-footer dark
                  padless fixed app>
            <v-card class="flex"
                    flat
                    tile>
                <v-card-text class="pa-0 white--text text-center grey text--secondary">
                        Controlled by: NSWC Corona Division, CUI Category: General Proprietary Business Information, Limited Distribution Control: FEDCON

                        <br> POC: Dean C Garcia (951) 768 - 2194
                </v-card-text>

                <v-card-text class="pa-0 white--text text-center purple darken-4">CUI
                </v-card-text>
            </v-card>
        </v-footer>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';
    import '@/assets/sram.css';

    @Component
    export default class Footer extends Vue {
        
    }
</script>
