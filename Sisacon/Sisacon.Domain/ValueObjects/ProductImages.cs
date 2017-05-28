using Sisacon.Domain.Entities;
using System;

namespace Sisacon.Domain.ValueObjects
{
    public class ProductImages : BaseEntity
    {
        #region Propeties

        public Byte[] Image { get; set; }
        public int IdProduct { get; set; }

        #endregion
    }
}
