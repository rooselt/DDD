using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces.Repositories
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
        List<Notification> getByUserId(int id);
    }
}
