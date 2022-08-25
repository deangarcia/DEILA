<template>
    <v-container fluid>
        <v-card class="ma-3 pa-3">
            <v-card-title primary-title>
                <div class="headline primary--text">Project Mission</div>
            </v-card-title>
            <v-card-text>
                Link to Code: https://github.com/deangarcia/DEILA
                <div class="headline font-weight-light ma-5">To develop a web application that can assist in the effort of creating an inclusive workplace environment. The web application will have two main features: The first feature is an inclusive language sentiment analyzer. And the second feature is a data acquisition and labeling interface. These features go hand in hand, as the data acquisition and labeling tool will contribute to the development of a more robust dataset for training the model in the first feature.</div>
            </v-card-text>
        </v-card>
    </v-container>
</template>

<script lang="ts">
    import { Component, Vue } from "vue-property-decorator";

    @Component
    export default class MyBenchmarks extends Vue {

    }
</script>