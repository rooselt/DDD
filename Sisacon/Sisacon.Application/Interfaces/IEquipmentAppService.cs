using Sisacon.Domain.Entities;

namespace Sisacon.Application.Interfaces
{
    public interface IEquipmentAppService : IAppServiceBase<Equipment>
    {
        ResponseMessage<Equipment> saveOrUpdate(Equipment equipment);
        ResponseMessage<Equipment> deleteEquipment(int equipmentId);
        ResponseMessage<Equipment> getEquipmentsByUserId(int userId);
        ResponseMessage<Equipment> GetCount(int userId);
    }
}
