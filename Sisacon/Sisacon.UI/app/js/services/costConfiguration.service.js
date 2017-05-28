(function () {

    'use strict';

    angular
        .module('app')
        .factory('costConfigurationService', costConfigurationService);

    function costConfigurationService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/costConfig';

        var service = {

            save: save,
            getCostConfigurationByUserId: getCostConfigurationByUserId
        }

        return service;

        function save(costConfig) {

            return $http.post(apiUrl + route, costConfig);

        }

        function getCostConfigurationByUserId(id) {

            return $http.get(apiUrl + route, {

                params: {

                    userId: id
                }
            })
        }
    }

})();