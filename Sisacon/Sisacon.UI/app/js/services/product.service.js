(function () {

    angular.module('app').factory('productService', productService);

    function productService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl + 'api/product';

        var service = {

            save: save,
            getProductById: getProductById,
            getProductByUserId: getProductByUserId,
            deleteProduct: deleteProduct
        }

        return service;

        function save(product) {

            return $http.post(apiUrl, product);
        }

        function getProductById(id) {

            return $http.get(apiUrl, {

                params: {

                    id: id
                }
            })
        }

        function getProductByUserId(userId) {

            return $http.get(apiUrl, {

                params: {

                    userId: userId
                }
            })
        }

        function deleteProduct(id) {

            return $http.delete(apiUrl, {

                params: {

                    id: id
                }
            })
        }
    }

})();