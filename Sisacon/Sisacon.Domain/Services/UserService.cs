using Helpers;
using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Sisacon.Domain.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfigurationService _configService;
        private readonly ICostConfigurationService _costConfigurationService;

        public UserService(IUserRepository repository, IConfigurationService configService, ICostConfigurationService costConfigurationService)
            : base(repository)
        {
            _repository = repository;
            _configService = configService;
            _costConfigurationService = costConfigurationService;
        }

        public User getByEmail(string email)
        {
            try
            {
                return _repository.getByEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> getListEmailInUse()
        {
            try
            {
                return _repository.getListEmailInUse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void inactivateUser(int id)
        {
            try
            {
                _repository.inactivateUser(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User logon(string pass, string email)
        {
            try
            {
                return _repository.logon(Security.Encrypt(pass), email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verifica se o email informado pelo usuário já está em uso.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>True se o email estiver já estiver em uso</returns>
        public bool emailInUse(string email)
        {
            var emailInUse = false;

            try
            {
                var emaIlList = getListEmailInUse();

                if (emaIlList.Contains(email))
                {
                    emailInUse = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return emailInUse;
        }

        public bool createDefaultConfig(User user)
        {
            var configCreated = false;

            try
            {
                //CRIA CONFIGURAÇÃO DE SISTEMA PADRÃO
                _configService.createDefaultConfiguration(user);

                //CRIA CONFIGURAÇÃO DE CUSTO MENSAL PADRÃO
                _costConfigurationService.createDefaultCostConfiguration(user);

                configCreated = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return configCreated;
        }

        public void updateLastLoginDate(User user)
        {
            try
            {
                user.LastLogin = DateTime.Now;

                _repository.update(user);

                _repository.commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
