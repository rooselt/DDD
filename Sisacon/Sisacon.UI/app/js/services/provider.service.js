(function () {

    'use strict';

    angular
        .module('app')
        .factory('providerService', providerService);

    function providerService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/provider';

        var service = {

            save: save,
            getProviderById: getProviderById,
            getProviderByUserId: getProviderByUserId,
            deleteProvider: deleteProvider
        };

        return service;

        function save(provider) {

            return $http.post(apiUrl + route, provider);

        }

        function getProviderById(idProvider) {

            return $http.get(apiUrl + route, {

                params: {

                    id: idProvider
                }
            });
        }

        function getProviderByUserId(userId) {

            return $http.get(apiUrl + route, {

                params: {

                    userId: userId
                }
            });
        }

        function deleteProvider(idProvider) {

            return $http.delete(apiUrl + route, {

                params: {

                    id: idProvider
                }
            });
        }
    }

})();