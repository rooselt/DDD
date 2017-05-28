using Sisacon.Application.Interfaces;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using Sisacon.Domain.Interfaces.Services;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.Sex;
using static Sisacon.Domain.Enuns.OperationType;
using System.Net;

namespace Sisacon.Application
{
    public class MaterialCategoryAppService : AppServiceBase<MaterialCategory>, IMaterialCategoryAppService
    {
        private readonly IMaterialCategoryService _materialCategoryService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public MaterialCategoryAppService(IMaterialCategoryService materialCategoryService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(materialCategoryService)
        {
            _materialCategoryService = materialCategoryService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<MaterialCategory> deleteMaterialCategory(int materialCategoryId)
        {
            var response = new ResponseMessage<MaterialCategory>();

            try
            {
                var materialCategory = _materialCategoryService.getById(materialCategoryId);

                if(materialCategory != null)
                {
                    if(materialCategory.validateBeforeDelete(materialCategory.User))
                    {
                        _materialCategoryService.delete(materialCategory);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Feminino, "Categoria");
                    }
                    else
                    {
                        response.Message = "Não é possível excluir esta Categoria, pois ela está sendo utilizada no momento.";
                        response.StatusCode = HttpStatusCode.BadRequest;
                    }
                }

                if(_materialCategoryService.commit() == 0)
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

        public ResponseMessage<MaterialCategory> getMaterialCategoryByUserId(int userId)
        {
            var response = new ResponseMessage<MaterialCategory>();
            response.ValueList = new List<MaterialCategory>();

            try
            {
                response.ValueList = _materialCategoryService.getByUserId(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<MaterialCategory> saveOrUpdate(MaterialCategory materialCategory)
        {
            var response = new ResponseMessage<MaterialCategory>();

            try
            {
                if(materialCategory.isValid())
                {
                    if(materialCategory.Id > 0)
                    {
                        _materialCategoryService.update(materialCategory);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Feminino, "Categoria");
                    }
                    else
                    {
                        _materialCategoryService.add(materialCategory);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Feminino, "Categoria");
                    }

                    if(_materialCategoryService.commit() == 0)
                    {
                        response.Message = _crudMsgFormater.createErrorCrudMessage();
                    }
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
