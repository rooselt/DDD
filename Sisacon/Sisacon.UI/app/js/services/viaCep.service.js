(function () {

    'use strict';

    angular
        .module('app')
        .factory('viaCepService', viaCepService);

    function viaCepService($http) {

        var service = {

            getAddress: getAddress
        };

        return service;

        function getAddress(cep) {

            return $http.get('http://viacep.com.br/ws/' + cep + '/json/ ');

        };
    };

})();

