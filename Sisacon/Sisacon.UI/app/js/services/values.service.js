(function () {

    angular.module('app').value('valuesService', {

        getApiUrl: 'http://localhost:15910/',

        //getApiUrl: 'http://beloartdesenvolvimento.azurewebsites.net/',

        getDefaultLogo: '../../../Content/UserImages/Default/CompanyLogo/default_logo.gif',

        errorFieldMessage : 'Os Campos destacados em Vermelho não foram preenchidos corretamente',

        dataTableLanguage: {
            "lengthMenu": "Exibindo _MENU_ Itens por página",
            "zeroRecords": "Nenhum resultado encontrado",
            "info": "Exibindo a página _PAGE_ de _PAGES_",
            "loadingRecords": "Carregando...",
            "infoEmpty": "Nenhum resultado encontrado",
            "search": "Procurar:",
            "infoFiltered": "(filtrado de _MAX_ itens)",
            "paginate": {
                "first": "Primeira",
                "last": "Última",
                "next": "Próxima",
                "previous": "Anterior"
            }
        },

        banks: [

            { id: '1', desc: '001 – Banco do Brasil S.A.' },
            { id: '2', desc: '341 – Banco Itaú S.A.' },
            { id: '3', desc: '033 – Banco Santander S.A.' },
            { id: '4', desc: '237 – Banco Bradesco S.A.' },
            { id: '5', desc: '745 – Banco Citibank S.A.' },
            { id: '6', desc: '399 – HSBC Bank Brasil S.A.' },
            { id: '7', desc: '104 – Caixa Econômica Federal' },
            { id: '8', desc: '389 – Banco Mercantil do Brasil S.A.' },
            { id: '9', desc: '748 – Banco Cooperativo Sicredi S.A.' }
        ],

        calendarText: {
            days: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S'],
            months: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
            monthsShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
            today: 'Hoje',
            now: 'Agora',
            am: 'AM',
            pm: 'PM'
        },

        monthsObjList : [

            { id: 0, text: 'Janeiro'},    
            { id: 1, text: 'Fevereiro'},
            { id: 2, text: 'Março'},
            { id: 3, text: 'Abril'},
            { id: 4, text: 'Maio'},
            { id: 5, text: 'Junho'},
            { id: 6, text: 'Julho'},
            { id: 7, text: 'Agosto'},
            { id: 8, text: 'Setembro'},
            { id: 9, text: 'Outubro'},
            { id: 10, text: 'Novembro'},
            { id: 11, text: 'Dezembro'},
        ]
    });

})();





