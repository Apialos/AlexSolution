// Place third party dependencies in the lib folder
// Configure loading modules from the lib directory,
// except 'app' ones, 
requirejs.config({
    //"baseUrl": "js",
    paths: {
        "jquery": "lib/jquery",
    }
});

// Start the main app logic.
requirejs([
    "lib/jquery",
    "modules/main"
]);