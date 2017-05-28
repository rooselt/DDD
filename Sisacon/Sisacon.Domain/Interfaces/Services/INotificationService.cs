using Sisacon.Domain.Entities;
using System.Collections.Generic;
using static Sisacon.Domain.Enuns.NotificationClass;

namespace Sisacon.Domain.Interfaces.Services
{
    public interface INotificationService : IServiceBase<Notification>
    {
        List<Notification> getByUserId(int id);
        Notification buildNotification(string message, eNotificationClass notificationClass, string link, User user);
    }
}
