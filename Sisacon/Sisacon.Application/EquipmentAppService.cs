using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class EquipmentAppService : AppServiceBase<Equipment>, IEquipmentAppService
    {
        private readonly IEquipmentService _equipmentService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public EquipmentAppService(IEquipmentService equipmentService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormate) : base(equipmentService)
        {
            _equipmentService = equipmentService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormate;
        }

        public ResponseMessage<Equipment> deleteEquipment(int equipmentId)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {
                var equipment = _equipmentService.getById(equipmentId);

                if (equipment != null && equipment.validatePendencesBeforeDelete())
                {
                    _equipmentService.delete(equipmentId);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Masculino, "Equipamento");
                }

                if (_equipmentService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Equipment> GetCount(int userId)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {

            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Equipment> getEquipmentsByUserId(int userId)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {
                response.ValueList = _equipmentService.getByUserId(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Equipment> saveOrUpdate(Equipment equipment)
        {
            var response = new ResponseMessage<Equipment>();

            try
            {
                if (equipment.isValid())
                {
                    if (equipment.Id > 0)
                    {
                        _equipmentService.update(equipment);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Masculino, "Equipamento");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(equipment.CodEquipment))
                        {
                            equipment.genereteCode();
                        }

                        _equipmentService.add(equipment);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Masculino, "Equipamento");
                    }

                    if (_equipmentService.commit() == 0)
                    {
                        response.Message = _crudMsgFormater.createErrorCrudMessage();
                    }

                    response.Value = equipment;
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }
    }
}
