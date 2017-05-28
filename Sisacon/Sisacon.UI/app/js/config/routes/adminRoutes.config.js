(function () {

    'use stricts';

    angular
        .module('app')

        .config(['$routeProvider', function ($routeProvider) {

            $routeProvider

                .when('/logDashboard', {

                    templateUrl: '/app/views/log/logDashboard.html',
                    controller: 'LogController',
                    controllerAs: 'vm'
                })
                .when('/logDetail', {

                    templateUrl: '/app/views/log/logDetail.html',
                    controller: 'LogController',
                    controllerAs: 'vm'
                });

        }])

})();