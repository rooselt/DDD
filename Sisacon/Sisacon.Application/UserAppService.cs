using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using Sisacon.Domain.ValueObjects;
using System;
using static Sisacon.Domain.Enuns.ErrorGravity;
using static Sisacon.Domain.Enuns.NotificationClass;
using static Sisacon.Domain.Enuns.OperationType;
using static Sisacon.Domain.Enuns.Sex;

namespace Sisacon.Application
{
    public class UserAppService : AppServiceBase<User>, IUserAppService
    {
        #region Interfaces

        private readonly IUserService _userService;
        private readonly ICrudMsgFormater _crudMsgFormater;
        private readonly INotificationService _notificationService;
        private readonly ILogAppService _logAppService;
        private readonly IClientService _clientService;
        private readonly IEquipmentService _equipmentService;
        private readonly IProviderService _provierService;
        private readonly IMaterialService _materialService;
        private readonly IProductService _productService;

        #endregion


        public UserAppService(IUserService userService, ICrudMsgFormater crudMsgFormater, INotificationService notificationService, ILogAppService logAppService, IClientService clientService, IEquipmentService equipmentService, IProviderService providerService, IMaterialService materialService, IProductService productService)
            : base(userService)
        {
            _userService = userService;
            _crudMsgFormater = crudMsgFormater;
            _notificationService = notificationService;
            _logAppService = logAppService;
            _clientService = clientService;
            _equipmentService = equipmentService;
            _provierService = providerService;
            _materialService = materialService;
            _productService = productService;
        }

        public ResponseMessage<User> createUser(User user)
        {
            var response = new ResponseMessage<User>();

            try
            {
                _userService.add(user);

                response.Quantity = _userService.commit();

                if (response.Quantity > 0)
                {
                    response.Value = user;

                    initConfigUser(user);

                    response.Message = _crudMsgFormater.createClientCrudMessage(eOperationType.Insert, eSex.Masculino, "Usuário");
                }
                else
                {
                    response.Message = _crudMsgFormater.createErrorCrudMessage();
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, user, eErrorGravity.Grande);

                return response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<User> emailInUse(string email)
        {
            var response = new ResponseMessage<User>();

            try
            {
                if (_userService.emailInUse(email))
                {
                    response.LogicalTest = true;
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);
            }

            return response;
        }

        public ResponseMessage<User> getByEmail(string email)
        {
            var response = new ResponseMessage<User>();

            try
            {
                response.Value = _userService.getByEmail(email);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);
            }

            return response;
        }

        public ResponseMessage<string> getListEmailInUse()
        {
            var response = new ResponseMessage<string>();

            try
            {
                response.ValueList = _userService.getListEmailInUse();
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Media);
            }

            return response;
        }

        public void inactivateUser(int id)
        {
            try
            {
                _userService.inactivateUser(id);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);
            }
        }

        public ResponseMessage<User> logon(string pass, string email)
        {
            var response = new ResponseMessage<User>();

            try
            {
                response.Value = _userService.logon(pass, email);

                if (response.Value == null)
                {
                    response.Message = "Usuário ou Senha incorretos, Caso tenha esquecido sua senha, clique em \"Esqueci Minha Senha\" para obter uma nova.";
                }
                else
                {
                    _userService.updateLastLoginDate(response.Value);
                }
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, null, eErrorGravity.Grande);
            }

            return response;
        }

        public void initConfigUser(User user)
        {
            try
            {
                //Cria as configurações iniciais para o usuário
                _userService.createDefaultConfig(user);

                //Cria notificação de cadastro de nova empresa
                _notificationService.buildNotification(MsgNotification.CreateCompany, eNotificationClass.Green, "#/company", user);
            }
            catch (Exception ex)
            {
                _logAppService.createClientLog(ex, user, eErrorGravity.Grande);
            }
        }

        public ResponseMessage<CountEntities> GetCountEntities(int userId)
        {
            var response = new ResponseMessage<CountEntities>();


            try
            {
                var countEntities = new CountEntities()
                {
                    ClientQuantity = _clientService.GetCount(userId),
                    EquipmentQuantity = _equipmentService.GetCount(userId),
                    ProviderQuantity = _provierService.GetCount(userId),
                    MaterialQuantity = _materialService.GetCount(userId),
                    ProductQuantity = _productService.GetCount(userId)
                };

                response.Value = countEntities;
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
