(function () {

    'use stricts';

    angular.module('app').controller('MaterialController', MaterialController);

    MaterialController.$inject = ['$scope', '$window', '$routeParams', 'configurationService', 'materialService', 'providerService', 'materialCategoryService', 'utilityService', 'localStorageService', 'blockUI', 'toastr'];

    function MaterialController($scope, $window, $routeParams, configurationService, materialService, providerService, materialCategoryService, utilityService, localStorageService, blockUI, toastr) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.material = {};
        vm.materialList = [];
        vm.priceReaserch = {};
        vm.configuration = {};
        vm.providers = [];
        vm.categories = [];
        vm.labels = [];
        vm.data = [[]];
        vm.btnSaveText = '';
        vm.idMaterialToRemove = '';

        //METHODS
        vm.loadConfiguration = loadConfiguration;
        vm.loadMaterial = loadMaterial;
        vm.loadCategories = loadCategories;
        vm.loadProviders = loadProviders;
        vm.loadMaterialList = loadMaterialList;
        vm.loadDataTables = loadDataTables;
        vm.newMaterial = newMaterial;
        vm.showModalEditCategory = showModalEditCategory;
        vm.addPriceResearch = addPriceResearch;
        vm.removePrice = removePrice;
        vm.submitForm = submitForm;
        vm.editMaterial = editMaterial;
        vm.showModalRemoveMaterial = showModalRemoveMaterial;
        vm.removeMaterialFromList = removeMaterialFromList;
        vm.removeMaterial = removeMaterial;

        initialize();

        function initialize() {

            vm.loadConfiguration();
            vm.loadProviders();
            vm.loadCategories();
            initObjectPriceResearch();

            if ($routeParams.id) {

                loadMaterial($routeParams.id);
            }
            else {

                loadMaterialList();
            }
        }

        function initObjectMaterial() {

            vm.material = {

                user: {
                    id: vm.userId
                },
                listPriceResearch: [],
                category: {
                    id: 0
                }
            };

        }

        function initObjectPriceResearch() {

            vm.priceReaserch = {

                material: {

                    id: 0
                },
                dateToView: ''
            };
        }

        function loadConfiguration() {

            if (vm.userId) {

                configurationService.getConfigurationByIdUser(vm.userId).success(function (response) {

                    vm.configuration = response.value;
                })
            }
        }

        function loadMaterial(id) {

            if (id > 0) {

                blockUI.start('Carregando Material');

                materialService.getMaterialById(id).success(function (response) {

                    response.value.registrationDate = utilityService.convertDateToString(response.value.registrationDate);

                    vm.btnSaveText = 'Atualizar';
                    vm.material = response.value;

                    if (vm.material.listPriceResearch == null) {

                        vm.material.listPriceResearch = [];
                    }

                    blockUI.stop();

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);

                })

            }
            else {

                if ($scope.materialForm) {

                    $scope.materialForm.$setPristine();
                }

                vm.btnSaveText = 'Salvar';

                initObjectMaterial();
            }

        }

        function loadProviders() {

            if (vm.userId) {

                providerService.getProviderByUserId(vm.userId).success(function (response) {

                    vm.providers = response.value;
                })
            }
        }

        function loadCategories() {

            if (vm.userId) {

                materialCategoryService.getCategoriesByUserId(vm.userId).success(function (response) {

                    vm.categories = response.valueList;
                })
            }
        }

        function loadDataTables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage);

        }

        function loadMaterialList() {

            blockUI.start('Carregando Materiais');

            materialService.getMaterialByUserId(vm.userId).success(function (response) {

                vm.materialList = response.valueList;

                blockUI.stop();

            }).error(function (response) {

                blockUI.stop();

                toastr.error('Erro ao carregar a lista de Materiais');
            })
        }

        function newMaterial() {

            if (!$scope.materialForm.$pristine) {

                angular.element('#newMaterialModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
            else {

                loadMaterial(0);
            }
        }

        function showModalEditCategory() {

            angular.element('#editCategory').modal({

                blurring: false,
                closable: true,
                autofocus: true,
                onHide: function () {

                    vm.loadCategories();
                }

            }).modal('show');

        }

        function submitForm() {

            $scope.materialForm.$setSubmitted();

            if ($scope.materialForm.$valid) {

                blockUI.start("Salvando Material...");

                vm.material.registrationDate = utilityService.convertStringToDate(vm.material.registrationDate);

                materialService.save(vm.material).success(function (response) {

                    blockUI.stop();

                    if (response.quantity > 0) {

                        vm.material = response.value;

                        toastr.success(response.message);

                        loadMaterial(vm.material.id);

                    }
                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        function editMaterial(id) {

            if (id > 0) {

                $window.location.href = "#/newMaterial?id=" + id;
            }
        }

        function showModalRemoveMaterial(material) {

            if (material.id) {

                vm.idMaterialToRemove = material.id;

                vm.nameMaterial = material.desc;

                angular.element('#removeMaterialModal').modal({

                    blurring: false,
                    closable: true

                }).modal('show');
            }
        }

        function removeMaterialFromList() {

            if (vm.idMaterialToRemove) {

                blockUI.start('Excluíndo Material...');

                materialService.deleteMaterial(vm.idMaterialToRemove).success(function (response) {

                    blockUI.stop();

                    if (response.quantity) {

                        toastr.success(response.message);

                        vm.idMaterialToRemove = 0;

                        loadMaterialList();
                    }

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        function removeMaterial() {

            if (vm.material.id) {

                blockUI.start('Excluíndo Material...');

                materialService.deleteMaterial(vm.idMaterialToRemove).success(function (response) {

                    blockUI.stop();

                    if (response.quantity) {

                        toastr.success(response.message);

                        vm.idMaterialToRemove = 0;

                        $window.location.href = "#/materialList";
                    }

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        function addPriceResearch() {

            $scope.priceResearchForm.$setSubmitted();

            if ($scope.priceResearchForm.$valid) {

                var priceReaserch = Object.assign({}, vm.priceReaserch);

                priceReaserch.searchDate = utilityService.convertStringToDate(priceReaserch.searchDate);

                priceReaserch.dateToView = utilityService.convertDateToString(priceReaserch.searchDate);

                addDataToGraphic(priceReaserch);

                vm.material.listPriceResearch.push(priceReaserch);
            }
        }

        function addDataToGraphic(priceReaserch) {

            //Adiciona as datas no grafico
            vm.labels.push(priceReaserch.dateToView);

            //Adiciona o valor do material no grafico
            var data = Object.assign([], vm.data[0]);

            data.push(vm.priceReaserch.price);

            vm.data = [];

            vm.data.push(data);

        }

        function removeDataFromGraphic(priceReaserch) {

            var indexLabel = vm.labels.indexOf(priceReaserch.dateToView);

            var indexPrice = vm.data[0].indexOf(priceReaserch.price);

            if (indexLabel > -1 && indexPrice > -1) {

                vm.labels.splice(indexLabel);
                vm.data.splice(indexPrice);
            }
        }

        function removePrice(priceReaserch) {

            if (priceReaserch) {

                var index = vm.material.listPriceResearch.indexOf(priceReaserch);

                vm.material.listPriceResearch.splice(index, 1);

                removeDataFromGraphic(priceReaserch);
            }
        }
    }

})();