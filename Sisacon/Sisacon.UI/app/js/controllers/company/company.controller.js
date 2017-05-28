(function () {

    angular
        .module('app')
        .controller('CompanyController', CompanyController);

    CompanyController.$inject = ['$scope', 'Upload', 'viaCepService', 'valuesService', 'companyService', 'toastr', 'blockUI', 'localStorageService', '$window'];

    function CompanyController($scope, Upload, viaCepService, valuesService, companyService, toastr, blockUI, localStorageService, $window) {

        //INIT CONTROLS
        angular.element('.ui.dropdown').dropdown();

        angular.element('.image').dimmer({

            on: 'hover'
        });

        angular.element('button').popup({
            on: 'click',
            position: 'right center'
        });

        //INIT VARIABLES
        $scope.defaultLogo = valuesService.getDefaultLogo;
        $scope.userId = localStorageService.get('id');
        $scope.user = localStorageService.get('user');
        $scope.company = {};
        $scope.showHelp = showHelp;
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

        loadCompany();
        loadOccupationAreas();

        //LOAD INFORMATIONS
        function showHelp() {

            angular.element('.ui.long.modal').modal({

                blurring: false,
                closable: true

            }).modal('show');
        };

        function loadCompany() {

            blockUI.start('Carregando Empresa...');

            companyService.getCompanyByUser($scope.userId).success(function (response) {

                blockUI.stop();
                $scope.company = response.value;

                //Caso não exista nenhuma empresa cadastrada para este usuário
                if (!$scope.company) {

                    initObjectCompany();
                }

                defineSaveOrUpdate();

            }).error(function (response) {

                blockUI.stop();
                toastr.error(response.message);

            });
        }

        function initObjectCompany() {

            $scope.company = {

                id: 0,
                eFormatImg: 1,
                ePersonType: 0,
                user: $scope.user,
                occupationArea: {

                    id: 0,
                    description: ''
                },
                address: {},
                contact: {}
            };
        }

        function loadOccupationAreas() {

            companyService.getOccupationAreas().success(function (response) {

                $scope.OccupationAreas = response.valueList;

            }).error(function () {

                console.log('Não foi possivel carregar as Areas de ocupação');
            });
        }

        function defineSaveOrUpdate() {

            if ($scope.company) {

                if ($scope.company.id === 0) {

                    $scope.btnSaveText = 'Salvar';
                }
                else {

                    $scope.btnSaveText = 'Atualizar';
                }
            }
        }

        //$SCOPE METHODS


        $scope.submitForm = function () {

            $scope.companyForm.$setSubmitted();
            $scope.save();
        };

        $scope.save = function () {

            if ($scope.companyForm.$valid) {

                companyService.save($scope.company).success(function (response) {

                    toastr.success(response.message);
                    $scope.btnSaveText = 'Atualizar';
                    loadCompany();

                }).error(function (response) {

                    toastr.error(response.message);
                });
            }
        };

        $scope.getAddress = function () {

            blockUI.start('Obtendo Endereço...');

            viaCepService.getAddress($scope.company.address.cep).success(function (response) {

                blockUI.stop();

                $scope.company.address.cep = response.cep;
                $scope.company.address.logradouro = response.logradouro;
                $scope.company.address.complemento = response.complemento;
                $scope.company.address.bairro = response.bairro;
                $scope.company.address.cidade = response.localidade;
                $scope.company.address.estado = response.uf;

            }).error(function (response) {

                blockUI.stop();
                console.log(response);
            });
        };

        $scope.showZoom = function () {

            angular.element('#modalZoomImage').modal({

                blurring: false,
                closable: true,
                autofocus: true

            }).modal('show');
        }

        $scope.addLogo = function (file, fileError) {

            if (file) {

                var formData = new FormData();
                formData.append("logo", file);

                blockUI.start('Atualizando Logotipo...');

                $.ajax({
                    url: 'http://localhost:15910/api/company/' + $scope.userId,
                    type: 'POST',
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (response) {

                        blockUI.stop();
                        toastr.success(response.message);
                        $scope.company = response.value;
                    },
                    error: function (response) {

                        blockUI.stop();
                        toastr.error(response.message);
                    }
                });
            }
            else{

                if (fileError[0] && fileError[0].$error == "maxSize") {

                    toastr.error('Não é possivel adicionar um Logotipo com mais de 3MB de tamanho. Favor escolher outra imagem.')
                }
            }
        };

        $scope.goToSite = function () {

            if ($scope.company.contact.urlSite) {

                $window.open($scope.company.contact.urlSite, '_blank');
            }
        }
    }

})();