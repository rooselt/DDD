(function () {

    angular
        .module('app')
        .config(function (uiMaskConfigProvider) {

            uiMaskConfigProvider.maskDefinitions({ 'A': /[a-z]/, '*': /[a-zA-Z0-9]/ });
            uiMaskConfigProvider.clearOnBlur(false);
            uiMaskConfigProvider.eventsToHandle(['input', 'keyup', 'click']);

        });
})();