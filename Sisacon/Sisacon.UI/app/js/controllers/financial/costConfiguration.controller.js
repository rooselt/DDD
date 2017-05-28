(function () {

    'use strict';

    angular
        .module('app')
        .controller('CostConfiguration', CostConfiguration);

    CostConfiguration.$inject = ['$scope', 'toastr', 'localStorageService', 'costConfigurationService'];

    function CostConfiguration($scope, toastr, localStorageService, costConfigurationService) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.user = localStorageService.get('user');
        vm.costConfiguration = {};

        //METHODS
        vm.save = save;
        vm.loadConfiguration = loadConfiguration;

        vm.loadConfiguration();

        function loadConfiguration() {

            costConfigurationService.getCostConfigurationByUserId(vm.userId).success(function (response) {

                vm.costConfiguration = response.value;

            }).error(function (response) {

                toastr.error(response.message);
            })
        }

        function save() {

            $scope.costConfigForm.$setSubmitted();

            if ($scope.costConfigForm.$valid && vm.costConfiguration.maxValue > 0) {

                costConfigurationService.save(vm.costConfiguration).success(function (response) {

                    toastr.success(response.message);

                }).error(function (response) {

                    toastr.error(response.message);

                })
            }
        }
    }

})();