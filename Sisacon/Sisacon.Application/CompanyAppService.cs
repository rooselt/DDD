using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using Sisacon.Domain.ValueObjects;
using System;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class CompanyAppService : AppServiceBase<Company>, ICompanyAppService
    {
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly ILogAppService _logAppService;
        private readonly ICrudMsgFormater _crudMsgFormater;
        private readonly IOccupationAreaService _occupationAreaService;

        public CompanyAppService(ICompanyService companyService,
            ILogAppService logAppService,
            ICrudMsgFormater crudMsgFormater,
            IOccupationAreaService occupationAreaService,
            IUserService userService) : base(companyService)
        {
            _companyService = companyService;
            _userService = userService;
            _logAppService = logAppService;
            _crudMsgFormater = crudMsgFormater;
            _occupationAreaService = occupationAreaService;
        }

        public ResponseMessage<Company> saveOrUpdate(Company company)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                if (company.Id > 0)
                {
                    _companyService.update(company);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Update, eSex.Feminino, "Empresa");
                }
                else
                {
                    _companyService.add(company);
                    updateStatusShowWellcome(company.User);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Feminino, "Empresa");
                }

                if (_companyService.commit() == 0)
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
                else
                {
                    response.Value = company;
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, company.User, eErrorGravity.Travamento);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Company> getCompanyByUserId(int userId)
        {
            var response = new ResponseMessage<Company>();

            try
            {
                response.Value = _companyService.getCompanyByUserId(userId);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Travamento);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<OccupationArea> getOccupationAreas()
        {
            var response = new ResponseMessage<OccupationArea>();

            try
            {
                response.ValueList = _occupationAreaService.getOccupationAreas();
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Travamento);

                return response.createErrorResponse();
            }

            return response;
        }

        /// <summary>
        /// Ao criar empresa, mensagem de boas vindas não deve mais ser exibida
        /// </summary>
        /// <param name="user"></param>
        private void updateStatusShowWellcome(User user)
        {
            var response = new ResponseMessage<User>();

            try
            {
                user.ShowWellcomeMessage = false;

                _userService.update(user);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Travamento);
            }
        }
    }
}
