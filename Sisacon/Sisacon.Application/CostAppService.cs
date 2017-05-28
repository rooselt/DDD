using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class CostAppService : AppServiceBase<Cost>, ICostAppService
    {
        private readonly ICostService _costService;
        private readonly ICostRepository _costRepository;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public CostAppService(ICostService costService, ICostRepository costRepository, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(costService)
        {
            _costService = costService;
            _costRepository = costRepository;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<Cost> DeleteCost(int costId)
        {
            var response = new ResponseMessage<Cost>();

            try
            {
                var cost = _costService.getById(costId);

                if (cost != null)
                {
                    if (cost.validateBeforeDelete())
                    {
                        _costService.delete(cost);

                        if (_costService.commit() == 0)
                        {
                            response.Message = _crudMsgFormater.createErrorCrudMessage();
                        }
                        else
                        {
                            response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Masculino, "Custo Mensal");
                        }
                    }
                    else
                    {
                        response.Message = "Não é possível excluir Custos de meses anteriores, apenas o Custo Atual.";
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

        public ResponseMessage<Cost> GetCurrentCost(int userId)
        {
            var response = new ResponseMessage<Cost>();

            try
            {
                var cost = _costRepository.GetCurrentCost(userId);

                if (cost != null)
                {
                    response.Value = cost;
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Cost> GetCostsByUserId(int userId)
        {
            var response = new ResponseMessage<Cost>();
            response.ValueList = new List<Cost>();

            try
            {
                response.ValueList = _costService.GetCostsByUserId(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Cost> SaveOrUpdate(Cost cost)
        {
            var response = new ResponseMessage<Cost>();

            try
            {
                if (cost.isValid())
                {
                    cost.calcCosts();

                    if (cost.Id > 0)
                    {
                        _costService.update(cost);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Masculino, "Custo Mensal");
                    }
                    else
                    {
                        _costService.add(cost);

                        response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Masculino, "Custo Mensal");
                    }
                }

                if (_costService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
                else
                {
                    response.Value = cost;
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Cost> ValidateNewCost(int UserId)
        {
            var response = new ResponseMessage<Cost>();

            try
            {
                var listCosts = _costService.GetCostsByUserId(UserId);

                response.LogicalTest = Cost.validateNewCost(listCosts);

                if (!response.LogicalTest)
                {
                    response.Message = string.Format("Não é possível criar mais de um Custo por Mês. Clique em Editar para alterar o Custo Atual");
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        //public ResponseMessage<Cost> getCostByCategory(int userId)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        _logAppService.createClientLog(ex, null, eErrorGravity.Grande);

        //        return response.createErrorResponse();
        //    }
        //}
    }
}
