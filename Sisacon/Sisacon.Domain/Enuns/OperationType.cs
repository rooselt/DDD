using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.Enuns
{
    public class OperationType
    {
        public enum eOperationType : short
        {
            Insert = 1,
            Update = 2,
            Select = 3,
            Delete = 4
        }
    }
}
