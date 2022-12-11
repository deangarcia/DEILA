<template>
    <div class="pb-16 mb-16">
        <v-toolbar light>
            <v-toolbar-title> Basis Key </v-toolbar-title>
            <v-spacer></v-spacer>
        </v-toolbar>
        <div>
            <v-data-table :headers="headers" :items="basiss" :items-per-page="10">
                <template v-slot:activator="{ headers }">
                    <tr>
                        <th v-for="header in headers"
                            :key="header.text"
                            @click="customSort(header.value)">
                            <v-icon v-if="!header.align || header.align === 'right'">arrow_upward</v-icon>
                            {{ header.text }}

                            <v-icon v-if="header.align === 'left'">arrow_upward</v-icon>
                        </th>
                    </tr>
                </template>
            </v-data-table>
        </div>
    </div>
</template>
<script lang="ts">
import { IBasis } from '@/interfaces/basis/index';
import { dispatchGetBasiss } from '@/store/basis/actions';
import { readBasiss } from '@/store/basis/getters';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Basiss extends Vue {
  public headers = [
    { text: 'ID', sortable: true, value: 'id' },
    { text: 'Category', sortable: true, value: 'category' },
  ];

  public async mounted() {
      await dispatchGetBasiss(this.$store);
  }

  get basiss() {
    const x: IBasis[] = readBasiss(this.$store);
    const ret = x;
    return ret;

  }
}
</script>