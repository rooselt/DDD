using Helpers;
using Sisacon.Domain.ValueObjects;
using System.Collections.Generic;

namespace Sisacon.Domain.Entities
{
    public class Product : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_DESCRIPTION = 100;
        public const int MAX_LENGTH_INFO = 500;

        #endregion

        #region Propeties

        public string CodProduct { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public decimal Value { get; set; }
        public decimal ProfitPercentage { get; set; }
        public int HoursToProduce { get; set; }
        public int MinutesToProduce { get; set; }
        public decimal CostPerHour { get; set; }
        public decimal TotalCostMaterials { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual List<Material> ListMaterial { get; set; }
        public virtual List<ProductImages> ListProductImages { get; set; }

        #endregion

        #region Methods

        public void GenereteCode()
        {
            CodProduct = string.Format("PRD{0}", Utils.GereneteRandomCode());
        }

        public bool ValidatePendencesBeforeDelete()
        {
            var valid = true;

            //implementar quando necessario

            return valid;
        }

        #endregion
    }
}
