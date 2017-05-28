(function () {

    'use strict';

    angular
        .module('app')
        .controller('LandingPageController', LandingPageController);

    LandingPageController.$inject = ['$scope', '$window'];

    function LandingPageController($scope, $window) {

        var vm = this;

        //angular.element('#carousel').carousel({ fullWidth: true });
    }

})();


