(function () {

    angular.
        module('app').
        controller('ProductController', ProductController);

    ProductController.$inject = ['$scope', 'blockUI', '$routeParams', 'toastr', 'productService', 'configurationService', 'materialService', 'costService', 'valuesService', 'localStorageService', 'DTOptionsBuilder', 'DTColumnBuilder'];

    function ProductController($scope, blockUI, $routeParams, toastr, productService, configurationService, materialService, costService, valuesService, localStorageService, DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        // VARIABLES   
        vm.product = {};
        vm.materials = [];
        vm.listProducts = [];
        vm.cost = {};
        vm.user = localStorageService.get('user');

        // METHODS
        vm.initialize = initialize;
        vm.loadConfiguration = loadConfiguration;
        vm.loadDatatables = loadDatatables;
        vm.loadProduct = loadProduct;
        vm.loadProductList = loadProductList;
        vm.loadMaterials = loadMaterials;
        vm.loadCost = loadCost;
        vm.showModalAddMaterial = showModalAddMaterial;
        vm.initObjectProduct = initObjectProduct;


        vm.initialize();

        function initialize() {

            //INITIALIZE COMPONENTS
            angular.element('button').popup({

                on: 'click',
                position: 'right center'
            });

            if ($routeParams.id) {

                vm.loadCost();
                vm.loadProduct($routeParams.id);
                vm.loadConfiguration();
            }
            else {

                vm.loadProductList();
            }

            vm.loadDatatables();
        }

        function loadProductList() {

            blockUI.start('Carregando Lista de Produtos...');

            productService.getProductByUserId(vm.user.id).success(function (response) {

                vm.listProducts = response.valueList;
                blockUI.stop();

            }).error(function (response) {

                toastr.error(response.message);
                blockUI.stop();
            })

        }

        function loadProduct(id) {

            if (id > 0) {

                blockUI.start('Carregando Produto...');

                productService.getProductById(id).success(function (response) {

                    vm.btnSaveText = 'Atualizar';
                    vm.product = response.value;
                    blockUI.stop();

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
            else {

                vm.btnSaveText = 'Salvar';
                initObjectProduct();
            }
        }

        function initObjectProduct() {

            vm.product = {

                id: 0,
                codProduct: '',
                desctiption: '',
                info: '',
                value: 0,
                profitPercentage: 0,
                hoursToProduce: 0,
                minutesToProduce: 0,
                costPerHour: vm.cost.costPerHour,
                totalCostMaterials: 0,
                setValueManually: false,
                userId: vm.user.id,
                listMaterial: [],
                listProductImages: []
            }
        }

        function loadConfiguration() {

            if (vm.user.id) {

                configurationService.getConfigurationByIdUser(vm.user.id).success(function (response) {

                    vm.configuration = response.value;

                }).error(function (response) {

                    console.log(response.message);
                })
            }
        }

        function loadDatatables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage)
                .withDisplayLength(10);
        }

        function loadMaterials() {

            materialService.getMaterialByUserId(vm.user.id).success(function (response) {

                vm.materials = response.valueList;

            }).error(function (response) {

                console.log(response.message);
            })
        }

        function loadCost() {

            costService.getCurrentCost(vm.user.id).success(function (response) {

                vm.cost = response.value;

                if (vm.cost) {

                    vm.product.costPerHour = vm.cost.costPerHour;
                }
            })
        }

        function showModalAddMaterial() {

            angular.element('#addMaterialModal').modal({

                blurring: false,
                closable: true,
                autofocus: true

            }).modal('show');
        }
    }

})();