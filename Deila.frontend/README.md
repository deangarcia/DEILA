# deila.frontend

## Project setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Lints and fixes files
```
npm run lint
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).

## Azure Deployment 
```
First go to your azure account and create a new web app resource
```
```
Second
open frontend project in visual studio code
open terminal in root frontend project
set the VUE_APP_DOMAIN_DEV in the .env file to the name of your app resource url in my case it was deila.azurewebsites.net
do npm run build
this will create a dist folder in your frontend root folder
```
Third
```
right click dist folder and select deploy to web app
select the resource created in step one
alert will pop up asking if you want to deploy click okay
now wait for it to deploy and you can browse website
```
