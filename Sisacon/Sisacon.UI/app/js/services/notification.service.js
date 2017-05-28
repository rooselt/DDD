(function () {

    'use strict';

    angular.module('app')
        .factory('notificationService', notificationService);

    function notificationService(valuesService, $http) {

        var apiUrl = valuesService.getApiUrl;

        var service = {

            getNotificationsByUserId: getNotificationsByUserId,
            updateStatusVisualized: updateStatusVisualized
        };

        return service;

        function getNotificationsByUserId(id) {

            return $http.get(apiUrl + 'api/notify', {

                params: {

                    id: id
                }
            });
        }

        function updateStatusVisualized(idUser) {
            
            return $http.put(apiUrl + 'api/notify?id=' + idUser);
        }
    }

})();