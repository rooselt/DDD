using Sisacon.Domain.Entities;
using System.Collections.Generic;

namespace Sisacon.Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User getByEmail(string email);
        List<string> getListEmailInUse();
        User logon(string pass, string email);
        void inactivateUser(int id);
    }
}
