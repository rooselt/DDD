(function () {

    'use strict';

    angular
        .module('app')
        .factory('costService', costService);

    function costService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/cost';

        var service = {

            save: save,
            getCostByUserId: getCostByUserId,
            getCostById: getCostById,
            deleteCost: deleteCost,
            validateNewCost: validateNewCost,
            getCurrentCost: getCurrentCost
        }

        return service;

        function save(cost) {

            return $http.post(apiUrl + route, cost);
        }

        function getCostByUserId(userId) {

            return $http.get(apiUrl + route, {

                params: {

                    userId: userId
                }
            })
        }

        function getCostById(id) {

            return $http.get(apiUrl + route, {

                params: {

                    id: id
                }
            })
        }

        function deleteCost(costId) {

            return $http.delete(apiUrl + route, {

                params: {

                    costId: costId
                }
            })
        }

        function validateNewCost(userId) {

            return $http.get(apiUrl + route + "/validateNewCost", {

                params: {

                    userId: userId
                }
            })
        }

        function getCurrentCost(userId) {
            
            return $http.get(apiUrl + route + "/getCurrentCost", {

                params: {

                    userId: userId
                }
            })
        }
    }


})();