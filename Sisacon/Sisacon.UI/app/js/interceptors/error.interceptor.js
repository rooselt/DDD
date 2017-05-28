(function () {

    angular
        .module('app')
        .factory('errorInterceptor', errorInterceptor);

    errorInterceptor.$inject = ['$q', '$window'];

    function errorInterceptor($q, $window) {

        return {

            responseError: function (rejection) {

                if (rejection.status === 404 || rejection.status === 500) {

                    $window.location.href = '#/errorPage';
                }

                return $q.reject(rejection);
            }

        };
    }

})();