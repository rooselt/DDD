(function () {

    'use strict';

    angular
        .module('app')
        .controller('ConfigurationController', ConfigurationController)

    ConfigurationController.$inject = ['configurationService', 'localStorageService', 'blockUI', 'toastr'];

    function ConfigurationController(configurationService, localStorageService, blockUI, toastr) {

        var vm = this;

        vm.loggedUser = localStorageService.get('id');
        vm.configuration = {};
        vm.pages = [];
        vm.initControls = initControls;
        vm.loadCbPages = loadCbPages;
        vm.getConfigurationByIdUser = getConfigurationByIdUser;
        vm.update = update;

        vm.initControls();
        vm.getConfigurationByIdUser();
        vm.loadCbPages();

        function initControls() {

            angular.element('.menu .item').tab();

        }

        function getConfigurationByIdUser() {

            blockUI.start('Obtendo Configurações...');

            configurationService.getConfigurationByIdUser(vm.loggedUser).success(function (response) {

                vm.configuration = response.value;

                blockUI.stop();

            }).error(function () {

                blockUI.stop();

            })

        }

        function loadCbPages() {

            vm.pages = [{

                id: '#/initialDashBoard',
                desc: 'Painel Inicial'

            },
            {

                id: '#/company',
                desc: 'Minha Empresa'

            },
            {

                id: '#/clientList',
                desc: 'Clientes'

            }];

        }

        function update() {

            if (vm.configuration) {

                configurationService.update(vm.configuration).success(function (response) {

                    toastr.success(response.message);

                }).error(function (response) {

                    toastr.error(response.message);

                })
            }

        }

    };

})();