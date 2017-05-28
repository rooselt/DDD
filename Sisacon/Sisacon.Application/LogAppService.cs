using Sisacon.Application.Interfaces;
using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Sisacon.Domain.Interfaces.Services;
using static Sisacon.Domain.Enuns.ErrorGravity;
using Sisacon.Domain.ValueObjects;
using static Sisacon.Domain.Enuns.UserType;

namespace Sisacon.Application
{
    public class LogAppService : AppServiceBase<Log>, ILogAppService
    {
        #region Constants

        private const string EVENT_LOG_SOURCE = "BeloArt";
        private const string EVENT_LOG_APP = "BeloArt Aplication Log";

        #endregion

        private readonly ILogService _logService;

        public LogAppService(ILogService logService) : base(logService)
        {
            _logService = logService;
        }

        public void createClientLog(Exception ex, User user, eErrorGravity gravity)
        {
            try
            {
                var log = createLogObj(ex, user, gravity);

                _logService.add(log);

                _logService.commit();
            }
            catch
            {
                createLogEventViewer(ex, user);
            }
        }

        public void createInternalLog(Exception ex, User user, eErrorGravity gravity)
        {
            try
            {
                var log = createLogObj(ex, user, gravity);

                _logService.add(log);

                _logService.commit();
            }
            catch
            {
                createLogEventViewer(ex, user);
            }
        }



        private void createLogEventViewer(Exception ex, User user)
        {
            try
            {
                if (!EventLog.SourceExists(EVENT_LOG_SOURCE))
                    EventLog.CreateEventSource(EVENT_LOG_SOURCE, EVENT_LOG_APP);

                var messagelog = string.Format("InnerException : {0}\nException : {1}", ex.InnerException, ex.Message);
                var messageFormated = string.Format("Usuário [{0}] - Log [{1}]", "horrander@outlook.com", messagelog);

                EventLog.WriteEntry(EVENT_LOG_SOURCE, messageFormated,
                    EventLogEntryType.Error, 234);
            }
            catch
            {
                createLogEventViewer(ex, user);
            }
        }

        /// <summary>
        /// Cria um objeto do tipo Log
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="user"></param>
        /// <param name="gravity"></param>
        /// <returns></returns>
        private Log createLogObj(Exception ex, User user, eErrorGravity gravity)
        {
            var log = new Log();

            try
            {
                log.eErrorGravity = gravity;
                log.InnerException = ex.InnerException != null ? ex.InnerException.InnerException.Message : string.Empty;
                log.StackTrace = ex.StackTrace;
                log.Message = ex.Message;

                if (user != null && user.isValid())
                {
                    log.User = user;
                }
                else
                {
                    log.User = createNonRegisteredUser();
                }
            }
            catch
            {
                createLogEventViewer(ex, user);
            }

            return log;
        }

        /// <summary>
        /// Quando não há um usuario logado, é criado um usuario padrão para o Log
        /// </summary>
        /// <returns></returns>
        private User createNonRegisteredUser()
        {
            var user = new User();

            try
            {
                user.Active = false;
                user.Id = 1;
                user.Email = "no_registered_user@user.com" ;
                user.eUserType = eUserType.Single;
                user.Password = "123456";
                user.RegistrationDate = DateTime.Now;
            }
            catch
            {

            }

            return user;
        }

        public ResponseMessage<Log> getLogs()
        {
            var response = new ResponseMessage<Log>();

            try
            {
                response.ValueList = _logService.getAll(true);
            }
            catch (Exception ex)
            {
                createClientLog(ex, createNonRegisteredUser(), eErrorGravity.Grande);

                response = response.createErrorResponse();
            }

            return response;
        }

        public ResponseMessage<Log> getLogById(int id)
        {
            var response = new ResponseMessage<Log>();

            try
            {
                response.Value = _logService.getById(id, true);
            }
            catch (Exception ex)
            {
                createClientLog(ex, createNonRegisteredUser(), eErrorGravity.Grande);

                response = response.createErrorResponse();
            }

            return response;
        }
    }
}
