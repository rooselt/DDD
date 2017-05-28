using Sisacon.Application.Interfaces;
using Sisacon.Domain.ValueObjects;
using System;
using Sisacon.Domain.Interfaces.Services;
using static Sisacon.Domain.Enuns.ErrorGravity;
using System.Net;
using static Sisacon.Domain.Enuns.Sex;
using static Sisacon.Domain.Enuns.OperationType;
using System.Collections.Generic;

namespace Sisacon.Application
{
    public class CostCategoryAppService : AppServiceBase<CostCategory>, ICostCategoryAppService
    {
        private readonly ICostCategoryService _costCategoryService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public CostCategoryAppService(ICostCategoryService costCategoryService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(costCategoryService)
        {
            _costCategoryService = costCategoryService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<CostCategory> deleteCostCategory(int costCategoryId)
        {
            var response = new ResponseMessage<CostCategory>();

            try
            {
                var costCategory = _costCategoryService.getById(costCategoryId);

                if(costCategory != null)
                {
                    if(costCategory.validateBeforeDelete())
                    {
                        _costCategoryService.delete(costCategory);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Feminino, "Categoria");
                    }
                    else
                    {
                        response.Message = "Não é possível excluir esta Categoria, pois ela está sendo utilizada no momento.";
                        response.StatusCode = HttpStatusCode.BadRequest;
                    }
                }

                if (_costCategoryService.commit() == 0)
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

        public ResponseMessage<CostCategory> getCostCategoryByUserId(int userId)
        {
            var response = new ResponseMessage<CostCategory>();
            response.ValueList = new List<CostCategory>();

            try
            {
                response.ValueList = _costCategoryService.getByUserId(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<CostCategory> saveOrUpdate(CostCategory costCategory)
        {
            var response = new ResponseMessage<CostCategory>();

            try
            {
                if(costCategory.Id > 0)
                {
                    _costCategoryService.update(costCategory);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Feminino, "Categoria");
                }
                else
                {
                    _costCategoryService.add(costCategory);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Feminino, "Categoria");
                }

                if(_costCategoryService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
                else
                {
                    response.Value = costCategory;
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
