<template>
  <div class="pb-16 mb-16" >
    <v-toolbar light>
      <v-toolbar-title> Manage Articles </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn color="primary" :to="{ name: 'article-add' }"
        >Add Article</v-btn
      >
    </v-toolbar>
    <div>
      <v-data-table :headers="headers" :items="articles" :items-per-page="50" 
      :single-expand="singleExpand"
        :expanded.sync="expanded"
        show-expand>
        <template v-slot:top>
          <v-toolbar flat>
        <v-switch
          v-model="singleExpand"
          label="Single Expand"
          class="mt-2"
        ></v-switch>
      </v-toolbar>
        </template>
        <template v-slot:[`item.sentiment`]="{ item }">
          <input
            :checked="item.sentiment"
            type="checkbox"
            id="item.id"
            @change="check(item.id, item.sentiment, item.basisId, item.content, item.title, item.origin)"
          />
        </template>
        <template v-slot:[`item.id`]="{ item }">
          <v-tooltip top>
            <span>Edit </span>
            <template v-slot:activator="{ on }">
              <v-btn
                small
                text
                v-on="on"
                :to="{
                  name: 'article-edit',
                  params: { id: item.id },
                }"
                ><v-icon>mdi-pencil</v-icon>
              </v-btn>
              {{
                  item.id
                }}
            </template>
          </v-tooltip>
          <v-tooltip top>
            <span>Delete </span>
            <template v-slot:activator="{ on }">
              <v-btn v-on="on" text @click="deleteArticle(item)"
                ><v-icon>mdi-delete</v-icon>
              </v-btn>
            </template>
          </v-tooltip>
        </template>
        <template v-slot:expanded-item="{ headers, item }">
          <td style="padding: 25px" :colspan="headers.length">
            <tr>
                <b> Origin: </b>
                {{
                  item.origin
                }}
            </tr>
            <br />
            <tr>
              {{
                item.content
              }}
            </tr>
          </td>
        </template>
        <template v-slot:activator="{ headers }">
          <tr>
            <th
              v-for="header in headers"
              :key="header.text"
              @click="customSort(header.value)"
            >
              <v-icon v-if="!header.align || header.align === 'right'"
                >arrow_upward</v-icon
              >
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
import { IArticle, IArticleUpdate } from '@/interfaces/article/index';
import {
  dispatchDeleteArticle,
  dispatchGetArticles,
  dispatchUpdateArticle,
} from '@/store/article/actions';
import { readArticles } from '@/store/article/getters';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Articles extends Vue {
  public policyValue: string | null | undefined = 'Test';
  public expanded: string[] = [];
  public singleExpand: boolean = true;
  public headers = [
    { text: 'Title', sortable: true, value: 'title', align: 'left' },
    { text: 'Category', sortable: true, value: 'basisId' },
    { text: 'Positive', sortable: true, value: 'sentiment' },
    { text: 'Actions', sortable: true, align: 'right', value: 'id' },
  ];

  public async mounted() {
    await dispatchGetArticles(this.$store);
  }

  get articles() {
    const x: IArticle[] = readArticles(this.$store);
    const ret = x;
    return ret;

  }

    public async check(input_id: number, new_sentiment: boolean, basis_Id: number, content: string, title: string, origin: string)
   {
       // Need to send rest of content 
      const updatedArticle: IArticleUpdate = {
          sentiment: !new_sentiment,
          basisId: basis_Id,
          content: content,
          title: title,
          origin: origin
      };
      await dispatchUpdateArticle(this.$store, {
        id: input_id,
        article: updatedArticle,
      });
      await dispatchGetArticles(this.$store);
  }

  public async deleteArticle(article: IArticle) {
      await dispatchDeleteArticle(this.$store, article);
      //or in file components
      await dispatchGetArticles(this.$store);
  }
}
</script>