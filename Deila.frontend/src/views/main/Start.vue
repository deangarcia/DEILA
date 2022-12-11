<template>
    <router-view></router-view>
    
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';

    const routeGuardStart = async (to, from, next) => {
        if (to.path === '/') {
            next('/main');
        } else {
            next();
        }
    };

@Component
export default class Start extends Vue {
  public beforeRouteEnter(to, from, next) {
      routeGuardStart(to, from, next);
  }

  public beforeRouteUpdate(to, from, next) {
      routeGuardStart(to, from, next);
  }
}
</script>
