(function () {

    'use strict';

    angular.module('app').controller('MaterialCategoryController', MaterialCategoryController);

    MaterialCategoryController.$inject = ['$scope', 'blockUI', 'toastr', 'localStorageService', 'materialCategoryService', 'valuesService','DTOptionsBuilder', 'DTColumnBuilder'];

    function MaterialCategoryController($scope, blockUI, toastr, localStorageService, materialCategoryService, valuesService,DTOptionsBuilder, DTColumnBuilder) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
        vm.user = localStorageService.get('user');
        vm.categories = [];
        vm.category = {};
        vm.btnSaveText = 'Adicionar Categoria';
        vm.btnSaveIcon = 'plus';

        //METHODS
        vm.initObjectCategory = initObjectCategory;
        vm.loadCategories = loadCategories;
        vm.save = save;
        vm.edit = edit;
        vm.deleteCategory = deleteCategory;
        vm.loadDataTables = loadDataTables;

        //INITIALIZE
        loadCategories();
        initObjectCategory();
        loadDataTables();

        function initObjectCategory() {

            vm.category = {

                user: vm.user
            }
        }

        function loadCategories() {

            if (vm.userId) {

                materialCategoryService.getCategoriesByUserId(vm.userId).success(function (response) {

                    vm.categories = response.valueList;

                }).error(function (response) {

                    toastr.error('Não foi possível carregar as Categorias');
                })
            }
        }

        function loadDataTables() {

            vm.dtOptions = DTOptionsBuilder
                .newOptions()
                .withPaginationType('full_numbers')
                .withLanguage(valuesService.dataTableLanguage);

        }

        function save() {

            $scope.modalCategoryForm.$setSubmitted();

            if ($scope.modalCategoryForm.$valid) {

                blockUI.start('Salvando Informações...');

                materialCategoryService.save(vm.category).success(function (response) {

                    blockUI.stop();

                    toastr.success(response.message);
                    loadCategories();

                    $scope.modalCategoryForm.$setPristine();
                    vm.initObjectCategory();

                    vm.btnSaveText = 'Adicionar Categoria';
                    vm.btnSaveIcon = 'plus';

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }

        function edit(categoryToEdit) {

            vm.category = categoryToEdit;

            //Remove o item a ser editado da lista
            var index = vm.categories.indexOf(categoryToEdit);
            vm.categories.splice(index, 1);

            vm.btnSaveIcon = 'check';
            vm.btnSaveText = 'Atualizar';
        }

        function deleteCategory(categoryId) {

            if (categoryId) {

                blockUI.start('Excluindo Categoria...');

                materialCategoryService.deleteCategory(categoryId).success(function (response) {

                    blockUI.stop();

                    toastr.success(response.message);
                    loadCategories();

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }
    }

})();