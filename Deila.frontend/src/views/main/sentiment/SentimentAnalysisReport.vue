<template>
    <v-container fluid>
        <v-card align="center">
            <v-card-title primary-title>
                <div class="headline primary--text">Sentiment Analysis Report</div>
            </v-card-title>
            <v-row justify="space-around">
                <v-spacer></v-spacer>
                    <v-avatar
                            color="red"
                            :size="neg_size"
                        ><span class="white--text text-h5">Negative</span></v-avatar>
                        <v-avatar
                            color="green"
                            :size="pos_size"
                        ><span class="white--text text-h5">Positive</span></v-avatar>
                        <v-spacer></v-spacer>
            </v-row>
            <v-card-actions>
                <v-btn @click="back">Back</v-btn>
            </v-card-actions>
        </v-card>
    </v-container>
</template>


<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
@Component
export default class SentimentAnalysis extends Vue {


  public back() {
    this.$router.back();
  }

  get neg_size()
  {
    return this.$router.currentRoute.params.neg;
  }

   get pos_size()
  {
    return this.$router.currentRoute.params.pos;
  }
}
</script>