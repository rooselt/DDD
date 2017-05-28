(function () {

    angular.module('app').controller('EquipmentController', EquipmentController);

    EquipmentController.$inject = ['$scope', '$window', 'blockUI', '$routeParams', 'toastr', 'utilityService', 'localStorageService', 'equipmentService', 'valuesService', 'configurationService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function EquipmentController($scope, $window, blockUI, $routeParams, toastr, utilityService, localStorageService, equipmentService, valuesService, configurationService,DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.equipment = {};
        vm.equipmentList = [];
        vm.nameEquipment = '';
        
        //METHODS
        vm.loadConfiguration = loadConfiguration;
        vm.loadDataTables = loadDataTables;
        vm.loadEquipment = loadEquipment;
        vm.loadEquipmentList = loadEquipmentList;
        vm.removeEquipment = removeEquipment;
        vm.initObjectEquipment = initObjectEquipment;
        vm.newEquipment = newEquipment;
        vm.submitForm = submitForm;
        vm.editEquipment = editEquipment;
        vm.showModalRemoveEquipment = showModalRemoveEquipment;
        vm.removeEquipmentFromList = removeEquipmentFromList;

        vm.loadDataTables();
        vm.loadConfiguration();

        //CASO EXISTA ALGUM VALOR NA URL, TRATA-SE DE EDIÇÃO, CASO NÃO TENHA É LISTAGEM 
        if ($routeParams.id) {

            loadEquipment($routeParams.id);
        }
        else {

            loadEquipmentList();
        }

        function loadConfiguration() {

            configurationService.getConfigurationByIdUser(vm.userId).success(function (response) {

                vm.configuration = response.value;

            }).error(function (response) {

                console.log(reponse.message);

            }
        )
        }

        function loadDataTables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage);

        }

        function loadEquipmentList() {

            blockUI.start("Carregando Equipamentos...");

            equipmentService.getEquipsByUserId(vm.userId).success(function (response) {

                vm.equipmentList = response.valueList;

                blockUI.stop();

            }).error(function (response) {

                blockUI.stop();
                toastr.error('Não foi possível carregar os Equipamentos');

            })
        }

        function loadEquipment(id) {

            if (id > 0) {

                vm.btnSaveText = 'Atualizar';

                equipmentService.getEquipById(id).success(function (response) {

                    response.value.registrationDate = utilityService.convertDateToString(response.value.registrationDate);
                    response.value.acquisitionDate = utilityService.convertDateToString(response.value.acquisitionDate);

                    vm.equipment = response.value;

                }).error(function (response) {

                    toastr.error(response.message);
                });
            }
            else {

                if ($scope.equipmentForm) {

                    $scope.equipmentForm.$setPristine();
                }

                vm.btnSaveText = 'Salvar';

                initObjectEquipment();
            }
        }

        function initObjectEquipment() {

            vm.equipment = {

                id: 0,
                user: {

                    id: vm.userId
                }
            }
        }

        function newEquipment() {

            if (!$scope.equipmentForm.$pristine) {

                angular.element('#newEquipmentModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
            else {

                loadEquipment(0);
            }
        }

        function submitForm() {

            $scope.equipmentForm.$setSubmitted();

            if ($scope.equipmentForm.$valid) {

                vm.equipment.registrationDate = utilityService.convertStringToDate(vm.equipment.registrationDate);
                vm.equipment.acquisitionDate = utilityService.convertStringToDate(vm.equipment.acquisitionDate);

                blockUI.start("Salvando Equipamento...");

                equipmentService.save(vm.equipment).success(function (response) {

                    blockUI.stop();
                    toastr.success(response.message);

                    response.value.registrationDate = utilityService.convertDateToString(response.value.registrationDate);
                    response.value.acquisitionDate = utilityService.convertDateToString(response.value.acquisitionDate);

                    vm.equipment = response.value;
                    vm.btnSaveText = "Atualizar"

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        function editEquipment(idEquipment) {

            if (idEquipment) {

                $window.location.href = "#/newEquipment?id=" + idEquipment;
            }
        }

        function removeEquipment() {

            if (vm.equipment.id) {

                equipmentService.deleteEquipment(vm.idEquipmentToRemove).success(function (response) {

                    if (response.logicalTest) {

                        toastr.success(response.message);

                        vm.idequipmentToRemove = 0;

                        $window.location.href = "#/equipmentList";
                    }

                }).error(function (response) {

                    toastr.error(response.message);
                })
            }
        }

        function showModalRemoveEquipment(equipment) {

            if (equipment.id) {

                vm.idEquipmentToRemove = equipment.id;

                $scope.nameEquipment = equipment.desc;

                angular.element('#removeEquipmentModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
        }

        function removeEquipmentFromList() {

            if (vm.idEquipmentToRemove) {

                equipmentService.deleteEquipment(vm.idEquipmentToRemove).success(function (response) {

                    if (response.quantity) {

                        toastr.success(response.message);

                        vm.idequipmentToRemove = 0;

                        loadEquipmentList();
                    }

                }).error(function (response) {

                    toastr.error(response.message);
                })
            }
        }

        function removeEquipment() {

            if (vm.equipment.id) {

                equipmentService.deleteEquipment(vm.idEquipmentToRemove).success(function (response) {

                    if (response.quantity) {

                        toastr.success(response.message);

                        vm.idequipmentToRemove = 0;

                        $window.location.href = "#/equipmentList";
                    }

                }).error(function (response) {

                    toastr.error(response.message);
                })
            }
        }
    }

})();

