<template>
    <v-container fluid>
        <v-card class="pb-16 mb-16" >
            <v-card-title primary-title>
                <div class="headline primary--text">Sentiment Analysis</div>
            </v-card-title>
            <v-card-text>
                <template>
                    <v-form v-model="valid">
                        <v-textarea clearable
                                    v-model="dei_text"
                                    clear-icon="mdi-close-circle"
                                    label="Sentiment Analysis Text"
                                    value="Insert text you want analyzed here."></v-textarea>
                    </v-form>
                </template>
            </v-card-text>
            <v-card-actions>
                <v-btn @click="cancel">Cancel</v-btn>
                <v-btn @click="reset">Reset</v-btn>
                <v-btn @click="submit" :disabled="!valid">Analyze</v-btn>
            </v-card-actions>
        </v-card>
    </v-container>
</template>


<script lang="ts">
import { ISentimentAnalysis } from "../../interfaces/sentiment";
import { Component, Vue } from 'vue-property-decorator';
import {
  dispatchGetSentiment,
} from '@/store/sentiment/actions';

import {
  readSentiment,
} from "@/store/sentiment/getters";
// Add store items and folder and set up API to just send back two logits and send it some text 
    // use that to figure out how to format GUI

    // Need sentiment analysis statistics need to compare it with the movie review model dataset
@Component
export default class SentimentAnalysis extends Vue {
  public valid = true;
  public dei_text = '';
  public reset() {
      this.dei_text = '';
  }
  public cancel() {
    this.$router.back();
  }

  get getSentiment() {
    const sentiment: ISentimentAnalysis = readSentiment(this.$store);
    return sentiment;
  }

  public async submit() {
    await dispatchGetSentiment(this.$store, this.dei_text);

    this.$router.push({ name: 'sentiment-report', params: { neg: this.getSentiment.negative, pos: this.getSentiment.positive,},});
  }
}
</script>