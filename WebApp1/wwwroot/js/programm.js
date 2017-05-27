// Place third party dependencies in the lib folder
// Configure loading modules from the lib directory,
// except 'app' ones, 
requirejs.config({
    paths: {
        "jquery": "lib/jquery",
        "vue": "lib/vue"
    }
});

// Start the main app logic.
requirejs([
    "modules/main"
]);