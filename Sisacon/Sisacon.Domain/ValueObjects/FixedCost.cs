using Sisacon.Domain.Entities;

namespace Sisacon.Domain.ValueObjects
{
    public class FixedCost : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_DESCRIPTION = 50;

        #endregion

        #region Propeties

        public string Description { get; set; }
        public decimal Value { get; set; }
        public int CostCategoryId { get; set; }
        public int CostId { get; set; }
        public CostCategory CostCategory { get; set; }

        #endregion

        #region Methods


        #endregion
    }
}
