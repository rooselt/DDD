(function () {

    'use strict';

    angular
        .module('app')
        .factory('configurationService', configurationService)

    function configurationService(valuesService, $http, $q) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/config';

        var service = {

            getConfigurationByIdUser: getConfigurationByIdUser,
            update: update
        }

        return service;

        function getConfigurationByIdUser(id) {

            return $http.get(apiUrl + route, {

                params: {

                    idUser: id
                }
            })

        }

        function update(config) {

            return $http.post(apiUrl + route, config);
        }
    }

})();