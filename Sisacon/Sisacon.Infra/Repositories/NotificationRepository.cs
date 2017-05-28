using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public override void add(Notification notification)
        {
            try
            {
                notification.RegistrationDate = DateTime.Now;

                Context.Notification.Add(notification);
                Context.User.Attach(notification.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Notification> getByUserId(int id)
        {
            var listNotification = new List<Notification>();

            try
            {
                listNotification = Context.Notification.Where(x => x.User.Id == id && x.Visualized == false).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listNotification;
        }
    }
}
