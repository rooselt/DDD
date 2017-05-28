(function () {

    angular
        .module('app')
        .factory('timestampInterceptor', timestampInterceptor);

    function timestampInterceptor() {

        return {

            request: function (config) {

                var url = config.url;

                if (url.indexOf('html') > -1 ||
                    url.indexOf('viacep') > -1 ||
                    url.indexOf('?') > -1) {

                    return config;
                }

                var timestamp = new Date().getTime();
                config.url = url + '?t=' + timestamp;

                console.log(config);

                return config;
            }
        };
    }

})();