using Sisacon.Domain.Entities;
using System;

namespace Sisacon.Domain.ValueObjects
{
    public class PriceResearch : BaseEntity
    {
        #region Propeties

        public decimal Price { get; set; }
        public int MaterialId { get; set; }
        public int ProviderId { get; set; }
        public virtual Material Material { get; set; }
        public virtual Provider Provider { get; set; }
        public DateTime SearchDate { get; set; }

        #endregion
    }
}
