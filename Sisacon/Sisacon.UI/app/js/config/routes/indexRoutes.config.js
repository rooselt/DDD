(function () {

    'use strict';

    angular
        .module('app')

        .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

            $locationProvider.html5Mode({
                enable: true,
                requireBse: false
            });

            $routeProvider

                .when('/company', {

                    templateUrl: '/app/views/company/company.html',
                    controller: 'CompanyController'
                })
                .when('/initialDashboard', {

                    templateUrl: '/app/views/InitialDashboard.html',
                    controller: 'InitialDashboardController',
                    controllerAs: 'vm'
                })
                //TOP MENU
                .when('/calendar', {

                    templateUrl: '/app/views/menu/calendar.html',
                    controller: 'CalendarController',
                    controllerAs: 'vm'

                })
                .when('/configuration', {

                    templateUrl: '/app/views/menu/configuration.html',
                    controller: 'ConfigurationController',
                    controllerAs: 'vm'

                })
                .when('/feedback', {

                    templateUrl: '/app/views/menu/feedback.html',
                    controller: 'FeedbackController',
                    controllerAs: 'vm'

                })
                .when('/myAccount', {

                    templateUrl: '/app/views/menu/myAccount.html',
                    controller: 'MyAccountController',
                    controllerAs: 'vm'

                })
                //CADASTROS
                .when('/clientList', {

                    templateUrl: '/app/views/entries/clientList.html',
                    controller: 'ClientController'
                })
                .when('/newClient', {

                    templateUrl: '/app/views/entries/newClient.html',
                    controller: 'ClientController'
                })
                .when('/newClient/:id', {

                    templateUrl: '/app/views/entries/newClient.html',
                    controller: 'ClientController'
                })
                .when('/providerList', {

                    templateUrl: '/app/views/entries/providerList.html',
                    controller: 'ProviderController',
                    controllerAs: 'vm'

                })
                .when('/newProvider', {

                    templateUrl: '/app/views/entries/newProvider.html',
                    controller: 'ProviderController',
                    controllerAs: 'vm'

                })
                .when('/newProvider/id', {

                    templateUrl: '/app/views/entries/newProvider.html',
                    controller: 'ProviderController',
                    controllerAs: 'vm'

                })
                .when('/equipmentList', {

                    templateUrl: '/app/views/entries/equipmentList.html',
                    controller: 'EquipmentController',
                    controllerAs: 'vm'
                })
                .when('/newEquipment', {

                    templateUrl: '/app/views/entries/newEquipment.html',
                    controller: 'EquipmentController',
                    controllerAs: 'vm'
                })
                .when('/newEquipment/id', {

                    templateUrl: '/app/views/entries/newEquipment.html',
                    controller: 'EquipmentController',
                    controllerAs: 'vm'
                })
                .when('/materialList', {

                    templateUrl: '/app/views/entries/materialList.html',
                    controller: 'MaterialController',
                    controllerAs: 'vm'
                })
                .when('/newMaterial', {

                    templateUrl: '/app/views/entries/newMaterial.html',
                    controller: 'MaterialController',
                    controllerAs: 'vm'
                })
                .when('/newMaterial/id', {

                    templateUrl: '/app/views/entries/newMaterial.html',
                    controller: 'MaterialController',
                    controllerAs: 'vm'
                })
                .when('/productList', {

                    templateUrl: '/app/views/entries/productList.html',
                    controller: 'ProductController',
                    controllerAs: 'vm'
                })
                .when('/newProduct', {

                    templateUrl: '/app/views/entries/newProduct.html',
                    controller: 'ProductController',
                    controllerAs: 'vm'
                })
                .when('/newProduct/id', {

                    templateUrl: '/app/views/entries/newProduct.html',
                    controller: 'ProductController',
                    controllerAs: 'vm'
                })
                //FINANCEIRO
                .when('/costsDashboard', {

                    templateUrl: '/app/views/financial/costsDashboard.html',
                    controller: 'CostsController',
                    controllerAs: 'vm'
                })
                .when('/costs', {

                    templateUrl: '/app/views/financial/costs.html',
                    controller: 'CostsController',
                    controllerAs: 'vm'
                })
                .when('/costs/id', {

                    templateUrl: '/app/views/financial/costs.html',
                    controller: 'CostsController',
                    controllerAs: 'vm'
                })
                .when('/estimateDashboard', {

                    templateUrl: '/app/views/estimate/estimateDashboard.html',
                    controller: 'EstimateController'
                })
                .when('/errorPage', {

                    templateUrl: '/app/views/errorPage.html'
                })
                .otherwise({

                   templateUrl: '/app/views/InitialDashboard.html',
                   controller: 'InitialDashboardController',
                   controllerAs: 'vm'
                });

        }]);



})();