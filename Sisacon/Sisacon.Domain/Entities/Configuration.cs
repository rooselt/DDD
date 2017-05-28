using Sisacon.Domain.Interfaces.Services;
using System;

namespace Sisacon.Domain.Entities
{
    public class Configuration : BaseEntity
    {
        #region Propeties

        public string DefaultPage { get; set; }
        public bool CodAutoClient { get; set; }
        public bool CodAutoProvider { get; set; }
        public bool CodAutoMaterial { get; set; }
        public bool CodAutoProduct { get; set; }
        public bool CodAutoEstimate { get; set; }
        public bool CodAutoRequest { get; set; }
        public bool CodAutoEquipment { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods

        public void createDefaultConfig(User user)
        {
            try
            {
                DefaultPage = "#/initialDashBoard";
                CodAutoClient = true;
                CodAutoProvider = true;
                CodAutoMaterial = true;
                CodAutoProduct = true;
                CodAutoEstimate = true;
                CodAutoRequest = true;
                CodAutoEquipment = true;
                User = user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
