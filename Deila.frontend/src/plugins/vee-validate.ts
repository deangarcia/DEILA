import Vue from 'vue';
import { ValidationProvider } from 'vee-validate';
import { ValidationObserver } from "vee-validate";

import { extend } from 'vee-validate';
import { required, email } from 'vee-validate/dist/rules';

// Add the required rule
extend('required', {
    ...required,
    message: 'This field is required'
});

// Add the valid url rule here
extend('email', {
    ...email,
    message: 'This field must be a valid email'
});
// Register it globally
// main.js or any entry file.
Vue.component('ValidationProvider', ValidationProvider);
Vue.component("ValidationObserver", ValidationObserver);