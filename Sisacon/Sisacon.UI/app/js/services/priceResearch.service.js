(function () {

    angular
        .module('app')
        .factory('priceResearchService', priceResearchService);

    function priceResearchService($http, valuesService) {

        var apiUrl = valuesService.getApiUrl;
        var route = 'api/priceResearch';

        var service = {

            save: save,
            deletePrice: deletePrice,
            getPriceById: getPriceById
        }

        return service;

        function save(price) {

            return $http.post(apiUrl + route, price);
        }

        function deletePrice(idPrice) {

            return $http.delete(apiUrl + route, {

                params: {

                    id: idPrice
                }
            })

        }

        function getPriceById(idPrice) {

            return $http.get(apiUrl + route, {

                params: {

                    idPriceResearch: idPrice
                }
            })
        }
    }

})();