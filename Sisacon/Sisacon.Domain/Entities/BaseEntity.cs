using System;

namespace Sisacon.Domain.Entities
{
    public abstract class BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_COD = 10;

        #endregion

        #region Properties

        public int Id { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? ExclusionDate { get; set; }

        #endregion
    }
}
