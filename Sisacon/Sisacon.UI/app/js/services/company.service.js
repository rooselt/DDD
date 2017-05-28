(function () {

    angular
        .module('app')
        .factory('companyService', companyService);

    function companyService(valuesService, $http) {

        var apiUrl = valuesService.getApiUrl;

        var service = {

            save: save,
            getCompanyByUser: getCompanyByUser,
            getOccupationAreas: getOccupationArea,
            addLogo: addLogo
        };

        return service;

        function save(company) {

            return $http.post(apiUrl + 'api/company', company);
        }

        function getCompanyByUser(idUser) {

            return $http.get(apiUrl + 'api/company', {

                params: {

                    id: idUser
                }
            });
        }

        function getOccupationArea() {

            return $http.get(apiUrl + 'api/company');
        }

        function addLogo(file, userId) {

            return $http.post(apiUrl + 'api/company/' + userId, file);
        }
    }

})();

