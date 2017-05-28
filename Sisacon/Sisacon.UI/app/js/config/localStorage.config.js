(function () {

    'use strict';

    angular
        .module('app')
        .config(function (localStorageServiceProvider) {

            localStorageServiceProvider
                .setPrefix('Sisacon')
                .setStorageType('localStorage')
                .setNotify(true, true);

        });

})();