<template>
  <v-container fluid>
    <v-card class="pb-16 mb-16" >
      <v-card-title primary-title>
        <div class="headline primary--text">Add Article</div>
      </v-card-title>
      <v-card-text>
        <template>
            <v-form v-model="valid">
                <v-text-field label="Title" v-model="title" required></v-text-field>
                <v-textarea clearable
                            v-model="content"
                            clear-icon="mdi-close-circle"
                            label="Content"
                            value="Article main body content."></v-textarea>
                <v-text-field label="Origin" v-model="origin" required></v-text-field>
                <v-select @change="selectBasis()"
                          id="basis_dd"
                          v-model="basis"
                          :items="getBasis"
                          :item-text="'category'"
                          :item-value="'id'"
                          label="Select Article Basis"
                          style="align: left; margin: 2px 2px; width: 500" />
                <v-select @change="selectSentiment()"
                          id="sentiment_dd"
                          v-model="sentiment"
                          :items="getSentiment"
                          :item-text="'text'"
                          :item-value="'sentiment'"
                          label="Select Sentiment"
                          style="align: left; margin: 2px 2px; width: 500" />
            </v-form>
        </template>
      </v-card-text>
      <v-card-actions>
        <v-btn @click="cancel">Cancel</v-btn>
        <v-btn @click="reset">Reset</v-btn>
        <v-btn @click="submit" :disabled="!valid">Save</v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { IArticleCreate } from '@/interfaces/article/index';
import { dispatchCreateArticle } from '@/store/article/actions';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class ArticleCreate extends Vue {
  public basis = 4;
  public origin = '';
  public title = '';
  public content = '';
  public sentiment = false;
  public valid = false;

    // TODO remove URL and add in manual title and content inputing scrapping would be to hard to add for this project
  // Pull this from the basis 
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
  public reset() {
    this.basis = 4;
    this.title = '';
    this.content = '';
    this.origin = '';
    this.sentiment = false;
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

  public async submit() {
      const newArticle: IArticleCreate = {
        title: this.title,
        content: this.content,
        basisId: this.basis,
        origin: this.origin,
        sentiment: this.sentiment,
      };
      await dispatchCreateArticle(this.$store, {
        article: newArticle,
      });
      this.$router.push({ name: 'article' });
  }
}
</script>