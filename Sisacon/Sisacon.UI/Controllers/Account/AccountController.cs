using AutoMapper;
using Sisacon.Application;
using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.UI.ViewModels;
using System.Net.Http;
using System.Web.Http;

namespace Sisacon.UI.Controllers.account
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        private readonly IUserAppService _userAppService;

        public AccountController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        [Route("user/login")]
        public HttpResponseMessage RegistrationUser(UserViewModel userViewModel)
        {
            var response = new ResponseMessage<User>();

            try
            {
                if (ModelState.IsValid)
                {
                    var user = Mapper.Map<UserViewModel, User>(userViewModel);

                    response = _userAppService.createUser(user);
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
        [Route("user")]
        public HttpResponseMessage GetUserById(int id)
        {
            var response = _userAppService.getById(id);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user")]
        public HttpResponseMessage ValidateEmailInUse(string email)
        {
            var response = _userAppService.emailInUse(email);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user")]
        public HttpResponseMessage Logon(string pass, string email)
        {
            var response = _userAppService.logon(pass, email);

            return Request.CreateResponse(response.StatusCode, response);
        }

        [HttpGet]
        [Route("user/count")]
        public HttpResponseMessage GetCountEntities(int userId)
        {
            var response = _userAppService.GetCountEntities(userId);

            return Request.CreateResponse(response.StatusCode, response);
        }
    }
}
