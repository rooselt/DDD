(function () {

    'use strict';

    angular
        .module('app')
        .factory('localStorageTeste', localStorageTeste);

    localStorageTeste.$inject = ['LocalStorageService'];

    function localStorageTeste(LocalStorageService) {

        return {

            setUserId: setUserId

        };

        function setUserId(id) {

            LocalStorageService('id', id);
        }
    }

})();