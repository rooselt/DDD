//(function () {

//    'use strict';

//    angular
//        .module('app')

//        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

//            $locationProvider.html5Mode({
//                enable: true,
//                requireBse: false
//            });

//            $routeProvider

//                .when('/landingPage', {

//                    templateUrl: '/app/views/landingPage.html'
//                })

//                .when('/singup', {

//                    templateUrl: '/app/views/account/singup.html',
//                    controller: 'SingUpController'
//                })
//                .when('/login', {

//                    templateUrl: '/app/views/account/login.html',
//                    controller: 'LoginController'
//                });
//        }]);

//})();