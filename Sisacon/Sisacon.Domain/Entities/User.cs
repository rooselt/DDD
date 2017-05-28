using Helpers;
using Sisacon.Domain.Interfaces.Services;
using Sisacon.Domain.ValueObjects;
using System;
using static Sisacon.Domain.Enuns.UserType;

namespace Sisacon.Domain.Entities
{
    public class User : BaseEntity
    {
        #region Constants

        public const int PASSWORD_MIN_LENGHT = 6;
        public const int EMAIL_MAX_LENGTH = 254;

        #endregion

        #region Propeties

        private bool _active;

        public bool Active
        {
            get { return _active; }

            set
            {
                //implementar regra para inativar usuario
                _active = value;
            }
        }

        public string Password { get; set; }
        public string Email { get; set; }
        public eUserType eUserType { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool ShowWellcomeMessage { get; set; }

        #endregion

        #region Constructors

        #endregion

        #region Methods

        public bool isValid()
        {
            var valid = true;

            if (Active == false)
            {
                valid = false;
            }
            else if (string.IsNullOrEmpty(Password))
            {
                valid = false;
            }
            else if (string.IsNullOrEmpty(Email))
            {
                valid = false;
            }

            return valid;
        }

        #endregion
    }
}
