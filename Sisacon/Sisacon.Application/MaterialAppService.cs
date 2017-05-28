using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class MaterialAppService : AppServiceBase<Material>, IMaterialAppService
    {
        private readonly IMaterialService _materialService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public MaterialAppService(IMaterialService materialService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(materialService)
        {
            _materialService = materialService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<Material> deleteMaterial(int MaterialId)
        {
            var response = new ResponseMessage<Material>();

            try
            {
                var material = _materialService.getById(MaterialId);

                if (material != null)
                {
                    if (material.ValidateBeforeDelete())
                    {
                        _materialService.delete(material);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Masculino, "Material");
                    }
                }

                if (_materialService.commit() == 0)
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

        public ResponseMessage<Material> getMaterialByUserId(int userId)
        {
            var response = new ResponseMessage<Material>();
            response.ValueList = new List<Material>();

            try
            {
                response.ValueList = _materialService.getByUserId(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Material> saveOrUpdate(Material material)
        {
            var response = new ResponseMessage<Material>();

            try
            {
                if (material.isValid())
                {
                    if (material.Id > 0)
                    {
                        material.CategoryId = material.Category.Id;

                        _materialService.update(material);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Masculino, "Material");
                    }
                    else
                    {
                        material.genereteCode();

                        _materialService.add(material);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Masculino, "Material");
                    }
                }

                if (_materialService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
                else
                {
                    response.Value = material;
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
