using System;
using static Sisacon.Domain.Enuns.NotificationClass;

namespace Sisacon.Domain.Entities
{
    public class Notification : BaseEntity
    {
        #region Propeties

        public string Message { get; set; }
        public string TimeSinceCreation
        {
            get
            {
                return calcTimeSinceCreation(RegistrationDate.Value);
            }
        }
        public eNotificationClass eNotificationClass { get; set; }
        public string Link { get; set; }
        public string NotificationClassCSS
        {
            get
            {
                switch (eNotificationClass)
                {
                    case eNotificationClass.Red:
                        {
                            return "red";
                        }
                    case eNotificationClass.Yellow:
                        {
                            return "yellow";
                        }
                    case eNotificationClass.Green:
                        {
                            return "green";
                        }
                    default:
                        return "green";
                }
            }

        }
        public bool Visualized { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods

        public string calcTimeSinceCreation(DateTime RegistrationDate)
        {
            try
            {
                var timeElapsed = new TimeSpan();

                var atualDate = DateTime.Now;

                {
                    timeElapsed = atualDate - RegistrationDate;

                    if (timeElapsed.Days > 1)
                    {
                        return timeElapsed.ToString("d' Dias atrás'");
                    }
                    else if (timeElapsed.Hours > 1)
                    {
                        return timeElapsed.ToString("h' Horas atrás'");
                    }
                    else if (timeElapsed.Minutes > 1)
                    {
                        return timeElapsed.ToString("m' Minutos atrás'");
                    }
                    else
                    {
                        return "Agora mesmo";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool isValid(string message, eNotificationClass notificationClass, string link, User user)
        {
            var valid = true;

            try
            {
                if (string.IsNullOrEmpty(message) || string.IsNullOrEmpty(link) || !user.isValid())
                {
                    valid = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return valid;
        }

        #endregion
    }
}
