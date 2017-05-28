(function () {

    'use strict';

    angular
        .module('app')
        .factory('utilityService', utilityService);

    function utilityService(valuesService) {

        var service = {

            validateDate: validateDate,
            convertStringToDate: convertStringToDate,
            createNewDate: createNewDate,
            convertDateToString: convertDateToString,
            getMonthText: getMonthText
        };

        return service;

        function validateDate(date) {

            var date = moment(date, 'YYYY/MM/DD').isValid();

            return date;

        }

        function convertDateToString(date) {

            var date = moment(date, moment.ISO_8601).format("DD-MM-YYYY");

            return date;
        }

        function convertStringToDate(strDate) {

            moment.locale('pt-BR');

            var date = moment(strDate, "DD-MM-YYYY");

            return date;
        }

        function createNewDate() {

            var date = moment().format();

            return date;
        }

        function getMonthText(numberMonth) {

            var month = '';

            // OBTEM A LISTA DOS MESES
            var listMonths = valuesService.monthsObjList;

            // PERCORRE A LISTA DE MESES E COMPARA SE O NUMERO DO MES É IGUAL AO PASSADO COMO PARAMETRO
            listMonths.forEach(function (item) {
                
                if(item.id == numberMonth){

                    month = item.text;
                }
            })

            return month;
        }
    }

})();