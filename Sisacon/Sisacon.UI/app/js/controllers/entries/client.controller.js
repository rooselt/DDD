
(function () {

    'use strict';

    angular
        .module('app')
        .controller('ClientController', ClientController);

    ClientController.$inject = ['$scope', '$window', 'blockUI', '$routeParams', 'toastr', 'viaCepService', 'utilityService', 'localStorageService', 'clientService', 'valuesService', 'configurationService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function ClientController($scope, $window, blockUI, $routeParams, toastr, viaCepService, utilityService, localStorageService, clientService, valuesService, configurationService, DTOptionsBuilder, DTColumnBuilder) {

        //INTIT CONTROLS
        angular.element('.ui.dropdown').dropdown();

        angular.element('button').popup({
            on: 'click',
            position: 'right center'
        });

        angular.element('.menu .item').tab();

        //VARIABLES
        $scope.userId = localStorageService.get('id');
        $scope.client = {};
        $scope.clientsF = [];
        $scope.clientsJ = [];
        $scope.userTypes = [];
        $scope.nameClient = '';
        $scope.loadClient = loadClient;
        $scope.configuration = {};

        //INIT OBJECTS
        loadConfigurations();
        loadUserTypes();
        loadSex();
        loadDataTables();

        //CASO EXISTA ALGUM VALOR NA URL, TRATA-SE DE EDIÇÃO, CASO NÃO TENHA É LISTAGEM 
        if ($routeParams.id) {

            loadClient($routeParams.id);
        }
        else {

            loadClientList();
        }

        //FUNCTIONS
        function loadConfigurations() {

            configurationService.getConfigurationByIdUser($scope.userId).success(function (response) {

                $scope.configuration = response.value;

            }).error(function (response) {

                console.log(reponse.message);

            })
        }

        function loadUserTypes() {

            $scope.userTypes = [

                {
                    id: 1,
                    desc: 'Pessoa Física'
                },
                {
                    id: 2,
                    desc: 'Pessoa Jurídica'
                }
            ];
        }

        function loadSex() {

            $scope.sexClient = [

                {
                    id: 1,
                    desc: 'Feminino'
                },
                {
                    id: 2,
                    desc: 'Masculino'
                }
            ];
        }

        function loadClient(id) {

            if (id > 0) {

                $scope.btnSaveText = 'Atualizar';

                clientService.getClientById(id).success(function (response) {

                    response.value.birthday = utilityService.convertDateToString(response.value.birthday);
                    response.value.registrationDate = utilityService.convertDateToString(response.value.registrationDate);

                    $scope.client = response.value;

                }).error(function (response) {

                    toastr.error(response.message);
                });
            }
            else {

                if ($scope.clientForm) {

                    $scope.clientForm.$setPristine();
                }

                $scope.btnSaveText = 'Salvar';
                
                initObjectClient();
            }
        }

        function loadClientList() {

            blockUI.start("Carregando clientes...");

            clientService.getClientByUserId($scope.userId).success(function (response) {

                $scope.clientsF = response.valueList[0];
                $scope.clientsJ = response.valueList[1];

                blockUI.stop();

            }).error(function (response) {

                blockUI.stop();
            })
        }

        function initObjectClient() {

            $scope.client = {

                id: 0,
                ePersonType: 1,
                sex: 0,
                rg: '',
                user: {

                    id: $scope.userId
                },
                sendAutomaticMsg: true,
                addBirthdayToCalendar: false,
                address: {},
                contact: {}
            }
        }

        function loadDataTables() {

            $scope.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage);
        }

        $scope.newClient = function () {

            if (!$scope.clientForm.$pristine) {

                angular.element('#newClientModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
            else {

                loadClient(0);
            }
        }

        $scope.submitForm = function () {

            $scope.clientForm.$setSubmitted();

            if ($scope.clientForm.$valid) {

                var date;
                var dateIsValid = true;
                var client = Object.assign({}, $scope.client);
                client.registrationDate = utilityService.convertStringToDate($scope.client.registrationDate);

                if (client.ePersonType === 1) {

                    date = $scope.clientForm.birthday.$viewValue;
                    dateIsValid = utilityService.validateDate(date);

                    if (dateIsValid) {

                        client.birthday = utilityService.convertStringToDate(date);
                    }
                    else {

                        $scope.clientForm.birthday.$valid = false;
                        return;
                    }
                }
                else {

                    client.birthday = utilityService.createNewDate();
                }

                blockUI.start("Salvando Cliente...");

                clientService.save(client).success(function (response) {

                    blockUI.stop();
                    toastr.success(response.message);

                    if (response.eOperationType == 1) {

                        $scope.client = response.value;
                    }

                    loadClient($scope.client.id);
                    
                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        $scope.editClient = function (idClient) {

            if (idClient) {

                $window.location.href = "#/newClient?id=" + idClient;
            }
        }

        $scope.showModalRemoveClient = function (client) {

            if (client.id) {

                $scope.idClientToRemove = client.id;

                if (client.ePersonType == 1) {

                    $scope.nameClient = client.clientName;
                }
                else{

                    $scope.nameClient = client.fantasyName;
                }

                angular.element('#removeClientModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
        }

        $scope.removeClientFromList = function () {

            if ($scope.idClientToRemove) {

                clientService.deleteClient($scope.idClientToRemove).success(function (response) {

                    if (response.logicalTest) {
                        
                        toastr.success(response.message);

                        loadClientList();
                    }

                }).error(function (response) {

                    toastr.error(response.message);
                })
            }
        }

        $scope.removeClient = function () {

            if ($scope.client.id) {

                clientService.deleteClient($scope.idClientToRemove).success(function (response) {

                    if (response.logicalTest) {
                        
                        toastr.success(response.message);

                        $window.location.href = "#/clientList";
                    }

                }).error(function (response) {

                    toastr.error(response.message);
                })
            }
        }

        $scope.getAddress = function () {

            blockUI.start('Obtendo Endereço...');

            viaCepService.getAddress($scope.client.address.cep).success(function (response) {

                blockUI.stop();

                $scope.client.address.cep = response.cep;
                $scope.client.address.logradouro = response.logradouro;
                $scope.client.address.complemento = response.complemento;
                $scope.client.address.bairro = response.bairro;
                $scope.client.address.cidade = response.localidade;
                $scope.client.address.estado = response.uf;

            }).error(function (response) {

                blockUI.stop();
                console.log(response);
            });
        };
    }

})();