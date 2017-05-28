(function () {

    'use strict';

    angular
        .module('app')
        .factory('materialCategoryService', materialCategoryService);

    function materialCategoryService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/materialCategory';

        var service = {

            save: save,
            getCategoriesByUserId: getCategoriesByUserId,
            getCategoryById: getCategoryById,
            deleteCategory: deleteCategory,

        };

        return service;

        function save(category) {

            return $http.post(apiUrl + route, category);

        }

        function getCategoriesByUserId(userId) {

            return $http.get(apiUrl + route, {

                params: {

                    userId: userId
                }
            })

        }

        function getCategoryById(id) {

            return $http.get(apiUrl + route, {

                params: {

                    id: id
                }
            })
        }

        function deleteCategory(categoryId) {

            return $http.delete(apiUrl + route, {

                params: {

                    categoryId: categoryId
                }
            })
        }

    }

})();

