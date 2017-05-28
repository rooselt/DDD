(function () {

    'use strict';

    angular
        .module('app')
        .factory('clientService', clientService);

    function clientService(valuesService, $http) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/client';

        var service = {

            save: save,
            getClientById: getClientById,
            getClientByUserId: getClientByUserId,
            deleteClient: deleteClient
        }

        return service;

        function save(client) {

            return $http.post(apiUrl + route, client);
        }

        function getClientById(idClient) {

            return $http.get(apiUrl + route, {

                params: {

                    id: idClient
                }
            });
        }

        function getClientByUserId(id) {

            return $http.get(apiUrl + route, {

                params: {

                    idUser: id
                }
            });
        }

        function deleteClient(id) {

            return $http.delete(apiUrl + route, {

                params: {

                    idClient: id
                }
            })
        }
    }

})();