using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.ValueObjects;
using Sisacon.UI.ViewModels;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class PriceResearchController : ApiController
    {
        private readonly IPriceResearchAppService _priceAppService;

        public PriceResearchController(IPriceResearchAppService priceAppService)
        {
            _priceAppService = priceAppService;
        }

        [HttpPost]
        [Route("priceResearch")]
        public HttpResponseMessage Save(PriceResearchViewModel priceResearchViewModel)
        {
            var response = new ResponseMessage<PriceResearch>();

            try
            {
                if (ModelState.IsValid)
                {
                    var priceResearch = Mapper.Map<PriceResearchViewModel, PriceResearch>(priceResearchViewModel);

                    response = _priceAppService.saveOrUpdate(priceResearch);
                }
                else
                {
                    response = response.createInvalidResponse();
                }
            }
            catch
            {
                response = response.createErrorResponse();
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("priceResearch")]
        public HttpResponseMessage GetPriceResearchById(int idPriceResearch)
        {
            var response = _priceAppService.getById(idPriceResearch, true);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpDelete]
        [Route("priceResearch")]
        public HttpResponseMessage Delete(int id)
        {
            var response = _priceAppService.deletePriceResearch(id);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
