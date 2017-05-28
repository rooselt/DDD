(function () {

    'use strict';

    angular
        .module('app')
        .controller('ProviderController', ProviderController);

    ProviderController.$inject = ['$scope', '$window', 'blockUI', '$routeParams', 'toastr', 'viaCepService', 'utilityService', 'localStorageService', 'valuesService', 'providerService', 'configurationService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function ProviderController($scope, $window, blockUI, $routeParams, toastr, viaCepService, utilityService, localStorageService, valuesService, providerService, configurationService, DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.user = localStorageService.get('user');
        vm.provider = {};
        vm.providerList = [];
        vm.nameProvider = '';
        vm.configuration = {};
        vm.banks = [];
        //METHODS
        vm.loadConfiguration = loadConfiguration;
        vm.initControls = initControls
        vm.loadDataTables = loadDataTables;
        vm.loadProvider = loadProvider;
        vm.loadBanks = loadBanks;
        vm.loadAccountType = loadAccountType;
        vm.removeProvider = removeProvider;
        vm.initObjectProvider = initObjectProvider;
        vm.newProvider = newProvider;
        vm.submitForm = submitForm;
        vm.editProvider = editProvider;
        vm.showModalRemoveProvider = showModalRemoveProvider;
        vm.removeProviderFromList = removeProviderFromList;
        vm.getAddress = getAddress;

        vm.initControls();
        vm.loadDataTables();
        vm.loadConfiguration();
        vm.loadBanks();
        vm.loadAccountType();

        //CASO EXISTA ALGUM VALOR NA URL, TRATA-SE DE EDIÇÃO, CASO NÃO TENHA É LISTAGEM 
        if ($routeParams.id) {

            loadProvider($routeParams.id);
        }
        else {

            loadProviderList();
        }

        function loadConfiguration() {

            configurationService.getConfigurationByIdUser(vm.userId).success(function (response) {

                vm.configuration = response.value;

            }).error(function (response) {

                console.log(reponse.message);

            }
                )
        }

        function initControls() {

            angular.element('.ui.dropdown').dropdown();

            angular.element('button').popup({
                on: 'click',
                position: 'right center'
            });

            angular.element('.menu .item').tab();

        }

        function loadDataTables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage);

        }

        function loadProviderList() {

            blockUI.start("Carregando Fornecedores...");

            providerService.getProviderByUserId(vm.userId).success(function (response) {

                vm.providerList = response.valueList;

                blockUI.stop();

            }).error(function (response) {

                blockUI.stop();
                toastr.error('Não foi possível carregar os Forncedores');

            })
        }

        function loadProvider(id) {

            if (id > 0) {

                vm.btnSaveText = 'Atualizar';

                providerService.getProviderById(id).success(function (response) {

                    response.value.registrationDate = utilityService.convertDateToString(response.value.registrationDate);

                    vm.provider = response.value;

                }).error(function (response) {

                    toastr.error(response.message);
                });
            }
            else {

                if ($scope.providerForm) {

                    $scope.providerForm.$setPristine();
                }

                vm.btnSaveText = 'Salvar';

                initObjectProvider();
            }
        }

        function loadBanks() {

            vm.banks = valuesService.banks;
        }

        function loadAccountType() {

            vm.accountType = [

                {
                    id: 1,
                    desc: 'Corrente'
                },
                {
                    id: 2,
                    desc: 'Poupança'
                }
            ];
        }

        function initObjectProvider() {

            vm.provider = {

                id: 0,
                user: vm.user,
                address: {},
                contact: {},
                bankDetails: {}
            }
        }

        function newProvider() {

            if (!$scope.providerForm.$pristine) {

                angular.element('#newProviderModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
            else {

                loadProvider(0);
            }
        }

        function submitForm() {

            $scope.providerForm.$setSubmitted();

            if ($scope.providerForm.$valid) {

                vm.provider.registrationDate = utilityService.convertStringToDate(vm.provider.registrationDate);

                blockUI.start("Salvando Fornecedor...");

                providerService.save(vm.provider).success(function (response) {

                    blockUI.stop();
                    toastr.success(response.message);

                    vm.provider = response.value;

                    response.value.registrationDate = utilityService.convertDateToString(response.value.registrationDate);

                    vm.btnSaveText = "Atualizar"

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        function editProvider(idProvider) {

            if (idProvider) {

                $window.location.href = "#/newProvider?id=" + idProvider;
            }
        }

        function showModalRemoveProvider(provider) {

            if (provider.id) {

                vm.idProviderToRemove = provider.id;

                $scope.nameProvider = provider.fantasyName;

                angular.element('#removeProviderModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
        }

        function removeProviderFromList() {

            if (vm.idProviderToRemove) {

                providerService.deleteProvider(vm.idProviderToRemove).success(function (response) {

                    toastr.success(response.message);

                    vm.idproviderToRemove = 0;

                    loadProviderList();

                }).error(function (response) {

                    toastr.error(response.message);
                })
            }
        }

        function removeProvider() {

            if (vm.provider.id) {

                providerService.deleteProvider(vm.idProviderToRemove).success(function (response) {

                    toastr.success(response.message);

                    vm.idproviderToRemove = 0;

                    $window.location.href = "#/providerList";

                }).error(function (response) {

                    toastr.error(response.message);
                })
            }
        }

        function getAddress() {

            blockUI.start('Obtendo Endereço...');

            viaCepService.getAddress(vm.provider.address.cep).success(function (response) {

                blockUI.stop();

                vm.provider.address.cep = response.cep;
                vm.provider.address.logradouro = response.logradouro;
                vm.provider.address.complemento = response.complemento;
                vm.provider.address.bairro = response.bairro;
                vm.provider.address.cidade = response.localidade;
                vm.provider.address.estado = response.uf;

            }).error(function (response) {

                blockUI.stop();
                console.log(response);
            });
        };
    }

})();