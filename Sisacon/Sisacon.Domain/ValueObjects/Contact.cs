using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.ValueObjects
{
    public class Contact : BaseEntity
    {
        #region Properties

        public string LandLine { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string UrlSite { get; set; }

        #endregion

        #region Constants

        public const int MAX_LENGTH_LAND_LINE = 10;
        public const int MAX_LENGTH_CELLPHONE = 11;
        public const int MAX_LENGTH_URL_SITE = 250;

        #endregion

    }
}
