using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.ValueObjects
{
    public class OccupationArea : BaseEntity
    {
        #region Properties

        public string Description { get; set; }

        #endregion
    }
}
