using System;

namespace Sisacon.Domain.Entities
{
    public class CostConfiguration : BaseEntity
    {
        #region Propeties

        public decimal MaxValue { get; set; }
        public bool IncludDevaluationOfEquipment { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods

        public void createDefaultConfiguration(User user)
        {
            try
            {
                MaxValue = 2000;
                IncludDevaluationOfEquipment = true;
                User = user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
