(function () {

    angular.module('app').directive('validateEmail', ['valuesService', 'accountService', 'blockUI', function (valuesService, accountService, blockUI) {

        return {

            restrict: 'A',
            require: ['ngModel'],
            replace: true,
            link: function (scope, element, attrs, ctrl) {

                element.bind('blur', function () {

                    var email = ctrl[0];

                    if (email.$valid) {

                        blockUI.start("Validando E-mail...");

                        accountService.getUsedEmail(email.$viewValue).success(function (response) {

                            blockUI.stop();

                            if (response.logicalTest) {

                                scope.errorMessage = response.message;
                                email.$valid = false;
                            }

                        }).error(function (response) {

                            blockUI.stop();
                        });
                    }
                });
            }
        };
    }]);


})();

