(function () {

    angular
        .module('app')
        .factory('materialService', materialService);

    function materialService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/material';

        var service = {

            save: save,
            deleteMaterial: deleteMaterial,
            getMaterialById: getMaterialById,
            getMaterialByUserId: getMaterialByUserId,
            getMaterialByCategory: getMaterialByCategory
        }

        return service;

        function save(material) {

            return $http.post(apiUrl + route, material);
        }

        function deleteMaterial(id) {

            return $http.delete(apiUrl + route, {

                params: {

                    id: id
                }
            })
        }

        function getMaterialById(id) {

            return $http.get(apiUrl + route, {

                params: {

                    id: id
                }
            })
        }

        function getMaterialByUserId(userId) {

            return $http.get(apiUrl + route, {

                params: {

                    userId: userId
                }
            })
        }

        function getMaterialByCategory(categoryId) {

            return $http.get(apiUrl + route, {

                params: {

                    categoryId: categoryId
                }
            })
        }
    }

})();