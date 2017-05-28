using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.UI.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Sisacon.UI.Controllers
{
    [RoutePrefix("api")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyAppService _companyAppService;

        public CompanyController(ICompanyAppService companyAppService)
        {
            _companyAppService = companyAppService;
        }

        [HttpPost]
        [Route("company")]
        public HttpResponseMessage Save(CompanyViewModel companyViewModel)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                if (ModelState.IsValid)
                {
                    var company = Mapper.Map<CompanyViewModel, Company>(companyViewModel);

                    response = _companyAppService.saveOrUpdate(company);
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

        [HttpPost]
        [Route("company/{idUser:int}")]
        public HttpResponseMessage AddLogo(int idUser)
        {
            var response = new ResponseMessage<Company>();


            try
            {
                var company = _companyAppService.getCompanyByUserId(idUser);

                if (company.Value != null)
                {
                    var httpRequest = HttpContext.Current.Request;

                    if (httpRequest.Files.Count > 0)
                    {
                        var stream = httpRequest.Files[0].InputStream;
                        var length = httpRequest.Files[0].ContentLength;

                        company.Value.Logo = ConvertHttpContextToByte(stream, length);

                        response = _companyAppService.saveOrUpdate(company.Value);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                    }
                }
                else
                {
                    response = response.createErrorResponse();
                }
            }
            catch (Exception)
            {
                response = response.createErrorResponse();
            }

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("company")]
        public HttpResponseMessage GetCompanyByUser(int id)
        {
            var response = _companyAppService.getCompanyByUserId(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("company")]
        public HttpResponseMessage GetOccupationArea()
        {
            var response = _companyAppService.getOccupationAreas();

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
