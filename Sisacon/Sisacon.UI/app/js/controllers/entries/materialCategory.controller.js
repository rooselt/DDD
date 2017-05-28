(function () {

    'use strict';

    angular.module('app').controller('MaterialCategoryController', MaterialCategoryController);

    MaterialCategoryController.$inject = ['$scope', 'blockUI', 'toastr', 'localStorageService', 'materialCategoryService'];

    function MaterialCategoryController($scope, blockUI, toastr, localStorageService, materialCategoryService) {

        var vm = this;

        //VARIABLES
        vm.userId = localStorageService.get('id');
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

        //INITIALIZE
        loadCategories();
        initObjectCategory();

        function initObjectCategory() {

            vm.category = {

                user: {

                    id: vm.userId
                }
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

                    if (response.quantity > 0) {

                        toastr.success(response.message);
                        loadCategories();
                    }
                    else {

                        toastr.error(response.message);
                    }

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);
                })
            }
        }
    }

})();