using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Domain.ValueObjects
{
    public class MaterialCategory : BaseEntity
    {
        #region Contructor

        //private readonly IMaterialService _materialService;

        //public MaterialCategory(IMaterialService materialService)
        //{
        //    _materialService = materialService;
        //}

        #endregion

        #region Constants

        public const int MAX_LENGTH_DESC = 50;

        #endregion

        #region Properties

        public string Description { get; set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods

        public bool isValid()
        {
            var valid = true;

            if(string.IsNullOrEmpty(Description))
            {
                valid = false;
            }

            return valid;
        }

        public bool validateBeforeDelete(User user)
        {
            var isValid = true;

            //var listMaterials = _materialService.getByUserId(user.Id);

            //foreach (var item in listMaterials)
            //{
            //    if(item.CategoryId == Id)
            //    {
            //        isValid = false;
            //    }
            //}

            return isValid;
        }

        #endregion

    }
}
