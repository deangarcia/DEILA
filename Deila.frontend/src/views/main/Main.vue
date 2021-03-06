<template>
    <div>
        <v-navigation-drawer persistent :mini-variant="miniDrawer" v-model="showDrawer" fixed app>
            <v-layout column fill-height>
                <v-list>
                    <v-subheader>Menu</v-subheader>
                    <v-list-item to="/main/dashboard">
                        <v-list-item-action>
                            <v-icon>mdi-web</v-icon>
                        </v-list-item-action>
                        <v-list-item-content>
                            <v-list-item-title>Dashboard</v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                </v-list>
                <v-divider></v-divider>
                <v-list>
                    <v-subheader>Admin Tools</v-subheader>
                    <v-list-item to="/main/dashboard">
                        <v-list-item-action>
                            <v-icon>mdi-web</v-icon>
                        </v-list-item-action>
                        <v-list-item-content>
                            <v-list-item-title>Dashboard</v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                </v-list>
            </v-layout>
        </v-navigation-drawer>
        <v-app-bar dark color="primary" app>
            <v-app-bar-nav-icon @click.stop="switchShowDrawer"></v-app-bar-nav-icon>
            <v-app-bar-title v-text="appName"></v-app-bar-title>
            <v-spacer></v-spacer>
            <v-menu bottom left offset-y>
            </v-menu>
        </v-app-bar>
        <v-main>
            <router-view></router-view>
        </v-main>
    </div>
</template>

<template>
    <div>
        <v-navigation-drawer persistent :mini-variant="miniDrawer" v-model="showDrawer" fixed app>
            <v-layout column fill-height>
                <v-list>
                    <v-subheader>Main Menu</v-subheader>
                    <v-list-item to="/main/dashboard">
                        <v-list-item-action>
                            <v-icon>mdi-web</v-icon>
                        </v-list-item-action>
                        <v-list-item-content>
                            <v-list-item-title>Dashboard</v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                </v-list>
                <v-divider></v-divider>
                <v-list>
                    <v-divider></v-divider>
                    <v-list-item @click="switchMiniDrawer">
                        <v-list-item-action>
                            <v-icon v-html="miniDrawer ? 'mdi-chevron-right' : 'mdi-chevron-left'"></v-icon>
                        </v-list-item-action>
                        <v-list-item-content>
                            <v-list-item-title>Collapse</v-list-item-title>
                        </v-list-item-content>
                    </v-list-item>
                </v-list>
            </v-layout>
        </v-navigation-drawer>
        <v-app-bar dark color="primary" app>
            <v-app-bar-nav-icon @click.stop="switchShowDrawer"></v-app-bar-nav-icon>
            <v-app-bar-title v-text="appName"></v-app-bar-title>
            <v-spacer></v-spacer>
            <v-menu bottom left offset-y>
                <v-btn slot="activator" icon>
                    <v-icon>mdi-dots-vertical</v-icon>
                </v-btn>
            </v-menu>
        </v-app-bar>
        <v-main>
            <router-view></router-view>
        </v-main>
    </div>
</template>

<script lang="ts">
    import { Vue, Component } from 'vue-property-decorator';

    import { appName } from '@/env';
    import { readDashboardMiniDrawer, readDashboardShowDrawer } from '@/store/main/getters';
    import { commitSetDashboardShowDrawer, commitSetDashboardMiniDrawer } from '@/store/main/mutations';

const routeGuardMain = async (to, from, next) => {
  if (to.path === '/main') {
    next('/main/dashboard');
  } else {
    next();
  }
};

@Component
export default class Main extends Vue {
    public appName = appName;


    public beforeRouteEnter(to, from, next) {
        routeGuardMain(to, from, next);
    }

    public beforeRouteUpdate(to, from, next) {
        routeGuardMain(to, from, next);
    }

    get miniDrawer() {
        return readDashboardMiniDrawer(this.$store);
    }

    get showDrawer() {
        return readDashboardShowDrawer(this.$store);
    }

    set showDrawer(value) {
        commitSetDashboardShowDrawer(this.$store, value);
    }

    public switchShowDrawer() {
        commitSetDashboardShowDrawer(
            this.$store,
            !readDashboardShowDrawer(this.$store),
        );
    }

    public switchMiniDrawer() {
        commitSetDashboardMiniDrawer(
            this.$store,
            !readDashboardMiniDrawer(this.$store),
        );
    }
}
</script>
