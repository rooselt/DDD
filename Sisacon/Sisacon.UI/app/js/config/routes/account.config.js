(function () {

    'use strict';

    angular
        .module('app')

        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

            $locationProvider.html5Mode({
                enable: false,
                requireBase: false
            });

            $routeProvider

                .when('/singup', {

                    templateUrl: '/app/views/account/singup.html',
                    controller: 'SingUpController'
                })
                .when('/login', {

                    templateUrl: '/app/views/account/login.html',
                    controller: 'LoginController'
                });
        }]);

})();