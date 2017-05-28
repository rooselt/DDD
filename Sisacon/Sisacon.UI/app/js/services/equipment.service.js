(function () {

    'use strict';

    angular.module('app').service('equipmentService', equipmentService);

    function equipmentService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = "api/equip";

        var service = {

            save: save,
            update: update,
            deleteEquipment: deleteEquipment,
            getEquipsByUserId: getEquipsByUserId,
            getEquipById: getEquipById
        }

        return service;

        function save(equipment) {

            return $http.post(apiUrl + route, equipment);

        }

        function update(equipment) {

            return $http.post(apiUrl + route, equipment);
        }

        function deleteEquipment(id) {

            return $http.delete(apiUrl + route, {

                params: {

                    id : id
                }
            })

        }

        function getEquipsByUserId(id) {

            return $http.get(apiUrl + route, {

                params: {

                    userId: id
                }
            })

        }

        function getEquipById(id) {

            return $http.get(apiUrl + route, {

                params: {

                    id: id
                }
            })

        }
    }

})();