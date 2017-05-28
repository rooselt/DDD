using Sisacon.Domain.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.ErrorGravity;

namespace Sisacon.Domain.Entities
{
    public class Log : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_MESSAGE = 1000;
        public const int MAX_LENGTH_INNER_EX = 2000;
        public const int MAX_LENGTH_STACKTRACE = 2000;

        #endregion

        #region Propeties

        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public eErrorGravity eErrorGravity { get; set; }

        #endregion
    }
}
