<template>
  <v-container fluid>
    <v-card class="pb-16 mb-16" >
      <v-card-title primary-title>
        <div class="headline primary--text">Edit Article</div>
      </v-card-title>
      <v-card-text>
        <template>
          <v-form v-model="valid">
               <v-text-field
              label="Title"
              v-model="title"
              required
            ></v-text-field>
            <v-textarea
              label="Content"
              v-model="content"
              required
            ></v-textarea>
            <v-select
                  id="basis_dd"
                  v-model="basis"
                  :items="getBasis"
                  :item-text="'category'"
                  :item-value="'id'"
                  label="Select Article Basis"
                  style="align: left; margin: 2px 2px; width: 500"
                />
            <v-select
                  id="sentiment_dd"
                  v-model="sentiment"
                  :items="getSentiment"
                  :item-text="'text'"
                  :item-value="'sentiment'"
                  label="Select Sentiment"
                  style="align: left; margin: 2px 2px; width: 500"
                />
          </v-form>
        </template>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="cancel">Cancel</v-btn>
        <v-btn @click="reset">Reset</v-btn>
        <v-btn @click="submit" :disabled="!valid">Save</v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>
<script lang="ts">
import { IArticleUpdate } from '@/interfaces/article/index';
import {
  dispatchGetArticles,
  dispatchUpdateArticle,
} from '@/store//article/actions';
import { readArticlesOne } from '@/store/article/getters';
import { Component, Vue } from 'vue-property-decorator';
@Component
export default class EditArticle extends Vue {
  public title = '';
  public content = '';
  public basis = 4;
  public sentiment = false;
  public valid = false;
  public origin = '';

  public basis_types = [
    { category: 'Gender', id: 1},
    { category: 'Race', id: 2},
    { category: 'Disability', id: 3},
    { category: 'Other', id: 4},
  ];

  public sentiment_options = [
    { text: 'Positive', sentiment: true},
    { text: 'Negative', sentiment: false},
  ];

  public async mounted() {
    await dispatchGetArticles(this.$store);
    let temp = readArticlesOne(this.$store)(+this.$router.currentRoute.params.id);
    if (temp != null) {
      this.title = temp.title;
      this.content = temp.content;
      this.basis = temp.basisId;
      this.sentiment = temp.sentiment;
      this.origin = temp.origin
    }
  }

  public reset() {
    this.title = '';
    this.content = '';
    this.basis = 4;
    this.sentiment = false;
    this.origin = '';
  }
  public cancel() {
    this.$router.back();
  }
  get getBasis() {
    return this.basis_types;
  }
  get getSentiment() {
    return this.sentiment_options;
    }

    public selectBasis()
    {

    }
  get article() {
    return readArticlesOne(this.$store)(+this.$router.currentRoute.params.id);
  }
  public async submit() {
      const updatedArticle: IArticleUpdate = {
        title: this.title,
        content: this.content,
        basisId: this.basis,
        sentiment: this.sentiment,
        origin: this.origin,
      };
      await dispatchUpdateArticle(this.$store, {
        id: this.article!.id,
        article: updatedArticle,
      });
    }
}
</script>
