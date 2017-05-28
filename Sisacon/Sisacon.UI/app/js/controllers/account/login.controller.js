(function () {

    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', 'accountService', 'localStorageService', 'configurationService', 'toastr', 'blockUI', '$window'];

    function LoginController($scope, accountService, localStorageService, configurationService, toastr, blockUI, $window) {

        $scope.config = {};
        $scope.idUser = 0;

        $scope.login = function () {

            if ($scope.loginForm.$valid) {

                blockUI.start('Validando Informações...');

                accountService.loginUser($scope.account).success(function (response) {

                    blockUI.stop();

                    if (response.value) {

                        $scope.User = response.value;

                        localStorageService.clearAll();
                        localStorageService.set('id', $scope.User.id);
                        localStorageService.set('user', $scope.User);

                        //eUserType 1 = Adminstrador do sistema
                        if (response.value.eUserType == 1) {

                            $window.location.href = 'Admin';
                        }
                        else {

                            loadSystem();
                        }
                    }
                    else {

                        toastr.error(response.message);
                    }

                }).error(function (response) {

                    blockUI.stop();
                    toastr.error(response.message);

                });
            }
        }

        function loadSystem() {

            configurationService.getConfigurationByIdUser($scope.User.id).success(function (response) {

                $scope.config = response.value;

                if ($scope.config) {

                    $window.location.href = 'Index' + $scope.config.defaultPage;
                }
                else {

                    $window.location.href = 'Index' + '#/initialDashboard';
                }

            }).error(function (response) {

                console.log(response.message);

            })



        }
    }

})();

