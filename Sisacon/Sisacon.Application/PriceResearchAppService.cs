using Sisacon.Application.Interfaces;
using Sisacon.Domain.Interfaces.Services;
using Sisacon.Domain.ValueObjects;
using System;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class PriceResearchAppService : AppServiceBase<PriceResearch>, IPriceResearchAppService
    {
        private readonly IPriceResearchService _priceService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;

        public PriceResearchAppService(IPriceResearchService priceService, ILogAppService logAppService, ICrudMsgFormater crudMsgFormater) : base(priceService)
        {
            _priceService = priceService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
        }

        public ResponseMessage<PriceResearch> deletePriceResearch(int priceResearchId)
        {
            var response = new ResponseMessage<PriceResearch>();

            try
            {
                var priceResearch = _priceService.getById(priceResearchId);

                if (priceResearch != null)
                {
                    _priceService.delete(priceResearch);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Delete, eSex.Feminino, "Pesquisa de Preço");
                }

                if (_priceService.commit() == 0)
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

        public ResponseMessage<PriceResearch> saveOrUpdate(PriceResearch priceResearch)
        {
            var response = new ResponseMessage<PriceResearch>();

            try
            {
                if (priceResearch.Id > 0)
                {
                    _priceService.update(priceResearch);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Feminino, "Pesquisa de Preço");
                }
                else
                {
                    priceResearch.SearchDate = DateTime.Now;
                    priceResearch.MaterialId = priceResearch.Material.Id;

                    _priceService.add(priceResearch);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Feminino, "Pesquisa de Preço");
                }

                if (_priceService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
                else
                {
                    response.Value = priceResearch;
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
