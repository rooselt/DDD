using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;

namespace Sisacon.Application.Interfaces
{
    public interface IUserAppService : IAppServiceBase<User>
    {
        ResponseMessage<User> createUser(User user);
        ResponseMessage<User> getByEmail(string email);
        ResponseMessage<string> getListEmailInUse();
        ResponseMessage<User> logon(string pass, string email);
        void inactivateUser(int id);
        ResponseMessage<User> emailInUse(string email);
        void initConfigUser(User user);
        ResponseMessage<CountEntities> GetCountEntities(int userId);
    }
}
