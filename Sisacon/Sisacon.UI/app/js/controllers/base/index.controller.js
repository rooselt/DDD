(function () {

    'use strict';

    angular
        .module('app')
        .controller('IndexController', IndexController);

    IndexController.$inject = ['$rootScope', '$scope', '$window', '$interval', 'accountService', 'localStorageService', 'notificationService'];

    function IndexController($rootScope, $scope, $window, $interval, accountService, localStorageService, notificationService) {

        //INIT OBJECTS
        $scope.loggedUser = {};
        getUserFromServer();
        $scope.notifications = getNotificationsByUserId();

        //A CADA 5 MINUTOS AS NOTIFICAÇÕES SÃO ATUALIZADAS
        $interval(getNotificationsByUserId, 10000);

        //INIT CONTROLS
        angular.element('#btnNotification').popup({

            on: 'click',
            popup: angular.element('#notificationPopup'),
            position: 'left center'

        });

        angular.element('#sidebar').accordion({

            on: 'click',
            collapsible: true,
            exclusive: true

        }).accordion();

        //FUNCTIONS
        $scope.openMenu = function () {

            angular.element('#sidebar').sidebar({

                closable: true,
                transition: 'push',
                mobileTransition: true,
                dimPage: true

            }).sidebar('toggle');
        };

        $scope.logout = function () {

            localStorageService.remove('id');
            $window.location.href = '/Home/LandingPage';

        }

        $scope.updateStatusVisualized = function (id) {

            notificationService.updateStatusVisualized(id).success(function (response) {

                if (response.logicalTest) {
                    getNotificationsByUserId(id);
                }

            }).error(function (response) {

                console.log(response);
            })
        }

        function getUserFromServer() {

            var userId = localStorageService.get('id');

            if (userId) {

                accountService.getUserById(userId).success(function (response) {

                    $scope.loggedUser = response.value;

                    if ($scope.loggedUser.showWellcomeMessage) {

                        angular.element('#wellcomeModal').modal({

                            blurring: true,
                            closable: false

                        }).modal('show');
                    }

                }).error(function (response) {

                    console.log(response);
                });
            }
            else {

                $window.location.href = '/Home/LandingPage#/login';
            }
        }

        function getNotificationsByUserId() {

            var userId = localStorageService.get('id');

            notificationService.getNotificationsByUserId(userId).success(function (response) {

                $scope.notifications = response.valueList;

            }).error(function (response) {

                console.log(response);
            })
        }
    }

})();