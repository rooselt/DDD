using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using static Sisacon.Domain.Enuns.NotificationClass;

namespace Sisacon.Domain.Services
{
    public class NotificationService : ServiceBase<Notification>, INotificationService
    {
        private readonly INotificationRepository _repository;

        public NotificationService(INotificationRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Notification buildNotification(string message, eNotificationClass notificationClass, string link, User user)
        {
            var notification = new Notification();

            try
            {
                notification.Message = message;
                notification.eNotificationClass = notificationClass;
                notification.Link = link;
                notification.User = user;
                notification.Visualized = false;

                _repository.add(notification);

                _repository.commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return notification;
        }

        public List<Notification> getByUserId(int id)
        {
            try
            {
                return _repository.getByUserId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
