<template>
    <v-container class="pb-16 mb-16" fluid>
        <v-card>
            <v-card-text>
                <strong class="headline primary--text ma-3 pa-3">How to Use This Site</strong>
                <p class="headline font-weight-light ma-3 pa-3">
                    To analyze text navigate to the Sentiment Analysis tab in the Main Menu. Once on this page, copy and paste text into the text area than click the Analyze button.
                </p>
                <p class="headline font-weight-light ma-3 pa-3">
                    To add new data to the dataset or modify existing data click on the Article Dataset tab in the main menu. On this page you will see a table listing the current contents of the dataset used to train the sentiment analysis model. To edit an existing article click on the pencil icon in the actions column of the article you want to edit. To add a new article click on the add article button in the top right corner of the Article Dataset page.
                </p>
                <v-divider class="ma-3 pa-3"></v-divider>
                <strong class="headline primary--text ma-3 pa-3">Project Overview</strong>
                    
                <p class=" headline font-weight-light ma-3 pa-3">
                    One way to help promote and increase diversity equity and inclusion in the workplace is through newsletters/emails and special observances. For these two tasks it is typical to generate informational artifacts with content that can unknowingly relay the wrong sentiment. One way to avoid this situation is by employing editors and legal advisors to vet and approve content to ensure they align with company creed prior to dissemination, this can be time consuming and costly. Time and cost can be reduced by using a machine learning model trained to perform text classification on inclusive text as having either a negative or positive sentiment. While there are many models that perform sentiment analysis, the models are trained on corpus’s that are ostensibly explicit, thereby making them inefficient when classifying inclusive language. 
                </p>
                <p class="headline font-weight-light ma-3 pa-3">
                    To assist in the effort of creating an inclusive workplace environment I have created this web application with two main features: The first feature is an inclusive language sentiment analyzer. And the second feature is a data acquisition and labeling interface. These features go hand in hand, as the data acquisition and labeling tool will contribute to the development of a more robust dataset for training the model in the first feature. 
                </p>

                <v-divider class="ma-3 pa-3"></v-divider>
                <strong class="headline primary--text ma-3 pa-3">Implementation & Design</strong>
                <p class="headline font-weight-light ma-3 pa-3">
                    The Software stack is composed of four azure resources a SQL database and three web applications (one to host the front-end web application, another to host the data acquisition tool and the last to host the sentiment analysis model). It was implemented using C#, .NET Core with Entity Framework, Vue and the model was developed using Python with OpenAIs pretrained model, GPT-2. For more details on the project codebase visit the Github links in the footer.
                </p >
                 <p class="headline font-weight-light ma-3 pa-3">
                    An iterative approach to developing the DEILA Sentiment Analysis model was taken. Attempts to improve the implementation of one of these 5 phases, creating the dataset, feature extraction, dimension reduction, classifier selection and evaluation were made as there was exposure to new techniques or methods of abstraction. More details can be seen by following the Project Write-Up link in the footer.
                </p >
                <v-divider class="ma-3 pa-3"></v-divider>
                <strong class="headline primary--text ma-3 pa-3">Model Evaluation</strong>
                    <p class=" headline font-weight-light ma-3 pa-3">
                    To evaluate the model I tested my original assumption which was that publicly available datasets are to explicit in nature and a model trained on these datasets would not accurately classify inclusive text. So I trained two control models one using Stanford's IMBD movie review dataset and the other using a Twitter Senitment Analysis dataset, with the same architecture and configurations as the DEILA model than tested each models accuracy using the DEILA validation set. I also attempt to verify that a larger inclusive text dataset would improve the models accuracy. Links to the dataset used for this project are provided in the footer.
                </p>
                <p class=" headline font-weight-light ma-3 pa-3">
                    Generally neither model was all that successful at classifying inclusive texts but the DEILA model performed the best with an accuracy score of 67%. More details on these test results can be seen by following the Project Write-Up link in the footer.
                </p>
            </v-card-text>
        </v-card>
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