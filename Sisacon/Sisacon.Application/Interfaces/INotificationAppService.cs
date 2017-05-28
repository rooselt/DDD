using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.NotificationClass;

namespace Sisacon.Application.Interfaces
{
    public interface INotificationAppService : IAppServiceBase<Notification>
    {
        ResponseMessage<Notification> getByUserId(int id);
        ResponseMessage<Notification> updateStatusVisualized(int id);
    }
}
