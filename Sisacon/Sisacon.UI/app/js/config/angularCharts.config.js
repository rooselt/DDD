﻿(function () {

    'use strict'

    angular
        .module('app')
        .config(function (ChartJsProvider) {

            ChartJsProvider.setOptions({ colors: ['#803690', '#00ADF9', '#DCDCDC', '#46BFBD', '#FDB45C', '#949FB1', '#4D5360'] });

        });

})();