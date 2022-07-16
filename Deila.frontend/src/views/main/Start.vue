<template>
    <router-view></router-view>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';

    const startRouteGuard = async (to, from, next) => {
        if (to.path === "/") {
            next("/main");
        } else {
            next();
        }
    };

    @Component
    export default class Start extends Vue {
        public beforeRouteEnter(to, from, next) {
            startRouteGuard(to, from, next);
        }

        public beforeRouteUpdate(to, from, next) {
            startRouteGuard(to, from, next);
        }
    }
</script>