using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application.Interfaces
{
    public interface ICrudMsgFormater
    {
        string createClientCrudMessage(eOperationType ePerationType, eSex eSex, string etity);
        string createErrorCrudMessage();
        string createMessageBySex(string messageF, string messageM, eSex sex, string entity);
    }
}
