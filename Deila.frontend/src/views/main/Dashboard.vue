<template>
    <v-container fluid>
         <v-row align="center">
            <v-item-group
            v-model="window"
            class="shrink ma-6"
            mandatory
            tag="v-flex"
            >
            <v-item
                v-for="n in length"
                :key="n"
                v-slot="{ active, toggle }"
            >
                <div>
                <v-btn
                    :input-value="active"
                    icon
                    @click="toggle"
                >
                    <v-icon>mdi-record</v-icon>
                </v-btn>
                </div>
            </v-item>
            </v-item-group>

            <v-col>
            <v-window
                v-model="window"
                class="elevation-1"
                vertical
            >
                <v-window-item
                v-for="n in length"
                :key="n"
                >
                <v-card flat>
                    <v-card-text>
                    <v-row
                        class="ma-3 pa-3"
                    >
                        <strong v-if="n === 1" class="headline primary--text">Overview</strong>
                        <strong v-if="n === 2" class="headline primary--text">Implementation</strong>
                        <strong v-if="n === 3" class="headline primary--text">Model Evaluation</strong>
                        <v-spacer></v-spacer>
                        <v-btn v-if="n === 1" icon>
                        <v-icon v-if="n === 1"> mdi-linkedin</v-icon>
                        </v-btn>
                        <v-btn v-if="n === 1" icon>
                        <v-icon v-if="n === 1"> mdi-gmail</v-icon>
                        </v-btn>

                        <v-btn v-if="n === 2" icon>
                        <v-icon v-if="n === 2"> mdi-file-word</v-icon>
                        </v-btn>
                        <v-btn v-if="n === 2" icon>
                        <v-icon v-if="n === 2"> mdi-github</v-icon>
                        </v-btn>

                        <v-btn v-if="n === 3" icon>
                            <v-icon v-if="n === 3"> mdi-file-word</v-icon>
                        </v-btn>
                        <v-btn v-if="n === 3" icon>
                            <v-icon v-if="n === 3"> mdi-github</v-icon>
                        </v-btn>
                    </v-row>

                    <p v-if="n === 1" class="headline font-weight-light ma-5">
                        One way to help promote and increase Diversity Equity & Inclusion in the workplace is through newsletters/emails and special observances. For these two tasks it is typical to generate informational artifacts with content that can unknowingly relay the wrong sentiment. One way to avoid this situation is by employing editors and legal advisors to vet and approve content to ensure they align with company creed prior to dissemination, this can be time consuming and costly. Time and cost can be reduced by using a machine learning model trained to perform text classification on inclusive text as having either a negative or positive sentiment. While there are many models that perform sentiment analysis, the models are trained on corpus’s that are ostensibly explicit, thereby making them inefficient when classifying inclusive language. 
                    </p>
                    <p v-if="n === 1" class="headline font-weight-light ma-5">
                        To assist in the effort of creating an inclusive workplace environment I have created this web application with two main features: The first feature is an inclusive language sentiment analyzer. And the second feature is a data acquisition and labeling interface. These features go hand in hand, as the data acquisition and labeling tool will contribute to the development of a more robust dataset for training the model in the first feature. 
                    </p>

                    <p v-if="n === 2" class="headline font-weight-light ma-5">
                        The Software stack is composed of four azure resources a SQL Database and three web applications (one to host the front end web application, another that hosts the data acquisition tool and the last to host the sentiment analysis model). It was implemented using C#, .NET Core with Entity Framework, Vue and the model was developed using Python with OpenAIs pretrained model, GPT-2.
                    </p >

                     <p v-if="n === 3" class="ma-3 pa-3">
                        In Section 6.2 I start by testing my original assumption which was that publicly available datasets are to explicit in nature to accurately classify inclusive text. So I trained two control models using Stanford's IMBD movie review dataset and a Twitter Senitment Analysis dataset I found on Kaggle. I trained these two control models using the same architectures and parameters as the DEILA model (4 epochs and a batch size of 32) than tested each models accuracy using the DEILA validation set. Accuracy is defined as the total number of correctly labeled samples, divided by the total number of samples. In Section 6.3 I modify the DEILA models parameters to try and improve the accuracy. I also attempt to verify that a larger inclusive text dataset would improve the models accuracy. 
                    </p>

                    <v-row
                        class="ma-3 pa-3"
                    >
                    <strong v-if="n === 1" class="headline primary--text">Guide</strong>
                    <strong v-if="n === 2" class="headline primary--text">Design</strong>
                    </v-row>

                    <p v-if="n === 1" class="headline font-weight-light ma-5">
                        To analyze text navigate to the Sentiment Analysis tab. Once on this page copy and paste text into the text area box than click the Analyze. After clicking analyze you will be directed to another page reporting the results.
                    </p>
                    <p v-if="n === 1" class="headline font-weight-light ma-5">
                       To add new data to the dataset or modify any existing data click on the Article Dataset tab in the main menu. On this page you will see a table listing the current contents of the dataset used to train the sentiment analysis model. To edit an existing article click on the pencil icon in the actions column the article you want to edit. To add a new article click on the add article button in the top right corner of the Article Dataset page. I have provided a link to my Github in the top right corner
                    </p>

                    <p v-if="n === 2" class="headline font-weight-light ma-5">
                        An iterative approach to developing the DEILA Sentiment Analysis model was taken. Attempts to improve the implementation of one of these 5 phases, creating the dataset, feature extraction, dimension reduction, classifier selection and evaluation were made as there was exposure to new techniques or methods of abstraction a more in depth description of the project can be seen in My Master Project Proposal. A link is provided in the top right.
                    </p >

                    <p v-if="n === 3" class="ma-3 pa-3">
                        In Section 6.2 I start by testing my original assumption which was that publicly available datasets are to explicit in nature to accurately classify inclusive text. So I trained two control models using Stanford's IMBD movie review dataset and a Twitter Senitment Analysis dataset I found on Kaggle. I trained these two control models using the same architectures and parameters as the DEILA model (4 epochs and a batch size of 32) than tested each models accuracy using the DEILA validation set. Accuracy is defined as the total number of correctly labeled samples, divided by the total number of samples. In Section 6.3 I modify the DEILA models parameters to try and improve the accuracy. I also attempt to verify that a larger inclusive text dataset would improve the models accuracy. 
                    </p>
                    </v-card-text>
                </v-card>
                </v-window-item>
            </v-window>
            </v-col>
        </v-row>
    </v-container>
</template>

<script lang="ts">
    import { Component, Vue } from "vue-property-decorator";

    @Component
    export default class MyBenchmarks extends Vue {
      public length = 3;
      public window = 0;    
    }
</script>