(function () {
    
    'use strict';

    angular
        .module('app')
        .config(function ($httpProvider) {
            
            //$httpProvider.interceptors.push('timestampInterceptor');
            $httpProvider.interceptors.push('errorInterceptor');
        });

})();