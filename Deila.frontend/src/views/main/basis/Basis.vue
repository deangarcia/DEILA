<template>
    <div>
        <v-toolbar light>
            <v-toolbar-title> Manage Basis </v-toolbar-title>
            <v-spacer></v-spacer>
            <v-btn color="primary" :to="{ name: 'basis-add' }">Add Basis</v-btn>
        </v-toolbar>
        <div>
            <v-data-table :headers="headers" :items="basiss" :items-per-page="10">
               
                <template v-slot:[`item.id`]="{ item }">
                    <v-tooltip top>
                        <span>Edit </span>
                        <template v-slot:activator="{ on }">
                            <v-btn small
                                   text
                                   v-on="on"
                                   :to="{
                  name: 'basis-edit',
                  params: { id: item.id },
                }">
                                <v-icon>edit</v-icon>
                            </v-btn>
                            {{
                  item.id
                            }}
                        </template>
                    </v-tooltip>
                    <v-tooltip top>
                        <span>Delete </span>
                        <template v-slot:activator="{ on }">
                            <v-btn v-on="on" text @click="deleteBasis(item)">
                                <v-icon>delete</v-icon>
                            </v-btn>
                        </template>
                    </v-tooltip>
                </template>
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
    { text: 'Category', sortable: true, value: 'Category' },
    { text: 'Incidents', sortable: true, value: 'Incidents' },
    { text: 'Actions', sortable: true, align: 'right', value: 'Id' },
  ];

  public async mounted() {
      await dispatchGetBasiss(this.$store);
  }

  get basiss() {
    const x: IBasis[] = readBasiss(this.$store);
    const ret = x;
    return ret;

  }

    public async deleteBasis(basis: IBasis) {
        return basis;
    //await dispatchDeleteBasis(this.$store, basis);
  }
}
</script>