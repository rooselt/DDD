using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces.Services;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Enuns;
using static Sisacon.Domain.Enuns.NotificationClass;
using static Sisacon.Domain.Enuns.ErrorGravity;

namespace Sisacon.Application
{
    public class NotificationAppService : AppServiceBase<Notification>, INotificationAppService
    {
        private readonly INotificationService _notificationService;

        private readonly ILogAppService _logService;

        public NotificationAppService(INotificationService notificatioService, ILogAppService logService) : base(notificatioService)
        {
            _notificationService = notificatioService;
            _logService = logService;
        }

        public ResponseMessage<Notification> getByUserId(int id)
        {
            var response = new ResponseMessage<Notification>();

            try
            {
                response.ValueList = _notificationService.getByUserId(id);
            }
            catch (Exception ex)
            {
                _logService.createClientLog(ex, null, eErrorGravity.Media);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Notification> updateStatusVisualized(int id)
        {
            var response = new ResponseMessage<Notification>();

            try
            {
                var notification = _notificationService.getById(id);

                if (notification != null)
                {
                    notification.Visualized = true;

                    _notificationService.update(notification);

                    response.Quantity = _notificationService.commit();

                    if (response.Quantity > 0)
                    {
                        response.LogicalTest = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }
    }
}
