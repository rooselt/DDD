(function () {

    'use strict';

    angular.module('app').factory('logService', logService);

    function logService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/log';

        var service = {

            getLogs: getLogs,
            getLogById: getLogById
        }

        return service;

        function getLogById(idLog) {

            return $http.get(apiUrl + route, {

                params: {

                    id : idLog
                }
            })

        }

        function getLogs() {

            return $http.get(apiUrl + route);
        }
    }

})();