using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sisacon.Domain.Entities
{
    public class Cost : BaseEntity
    {
        #region Propeties

        public string ReferenceMonthText { get; set; }
        public int WorkedHours { get; set; }
        public decimal Salary { get; set; }
        public decimal TotalFixedCost { get; set; }
        public decimal TotalDevaluationOfEquipment { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CostPerHour { get; set; }
        public bool Closed { get; set; }
        public bool Current { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public List<FixedCost> ListFixedCost { get; set; }

        #endregion

        #region Methods

        public bool isValid()
        {
            var isValid = true;



            return isValid;
        }

        /// <summary>
        /// Valida se um Custo pode ser removido.
        /// </summary>
        /// <returns></returns>
        public bool validateBeforeDelete()
        {
            var isValid = true;

            //SÓ É POSSIVEL DELETEAR O CUSTO DO MES ATUAL, DURANTE O PERIODO EM QUE ELE ESTEJA VIGENTE, APÓS ESSE PERIODO, NÃO PODERÁ MAIS SER REMOVIDO, POR QUESTOES DE MANUTENÇÃO DE HISTORICO
            if (!Current)
            {
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Valida se é permitido criar um novo custo, lembrando que só pode haver um custo por mes
        /// </summary>
        /// <param name="listCosts">Lista de custos do usuario</param>
        /// <returns></returns>
        public static bool validateNewCost(List<Cost> listCosts)
        {
            bool isValid = true;

            if (listCosts != null && listCosts.Count > 0)
            {
                var currentCost = listCosts.Select(x => x.RegistrationDate).FirstOrDefault();

                if (currentCost.Value.Month == DateTime.Now.Month)
                {
                    isValid = false;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Calcula o total dos gastos fixos.
        /// </summary>
        public void calcCosts()
        {
            TotalFixedCost = 0;

            //O TOTAL DE CUSTOS FIXOS É A SOMA DE TODOS OS GASTOS MENSAIS EX: AGUA, LUZ, CELULAR
            foreach (var item in ListFixedCost)
            {
                TotalFixedCost += item.Value;
            }

            //O TOTAL DO CUSTO É A SOMA DO SALARIO + TOTAL DA DESVALORIZAÇÃO + A SOMA DE TODOS OS CUSTOS FIXOS
            TotalCost = Salary + TotalDevaluationOfEquipment + TotalFixedCost;

            //O VALOR DA HORA TRABALHADA É SOMA DE TODOS OS GASTOS DIVIDIDO PELA QUANTIDADE DE HORAS TRABALHADAS
            if (WorkedHours > 0)
            {
                CostPerHour = TotalCost / WorkedHours;
            }
        }

        #endregion
    }
}
