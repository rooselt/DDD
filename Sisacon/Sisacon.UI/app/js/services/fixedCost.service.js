(function () {

    'use strict';

    angular.module('app').factory('fixedCostService', fixedCostService);

    function fixedCostService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/fixedCost';

        var service = {

            save: save,
            deleteFixedCost: deleteFixedCost,
            getFixedCostById: getFixedCostById
        }

        return service;

        function save(fixedCost) {

            return $http.post(apiUrl + route, fixedCost);
        }

        function deleteFixedCost(id) {

            return $http.delete(apiUrl + route, {

                params: {

                    id: id
                }
            })
        }

        function getFixedCostById(id) {
            
            return $http.get(apiUrl + route,{

                params: {

                    id : id
                }
            })
        }
    }

})();