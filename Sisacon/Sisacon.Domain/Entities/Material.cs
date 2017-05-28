using Helpers;
using Sisacon.Domain.ValueObjects;
using System.Collections.Generic;

namespace Sisacon.Domain.Entities
{
    public class Material : BaseEntity
    {
        #region Constants

        public const int MAX_LENGTH_DESC = 50;
        public const int MAX_LENGTH_NOTE = 250;

        #endregion

        #region Propeties

        public string CodMaterial { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public virtual MaterialCategory Category { get; set; }
        public virtual List<PriceResearch> ListPriceResearch { get; set; }
        public virtual List<Product> ListProduct { get; set; }
        public virtual User User { get; set; }
        public decimal CurrentPrice
        {
            get
            {
                decimal price = 0;

                if (ListPriceResearch != null && ListPriceResearch.Count > 0)
                {
                    int currentPriceIndex = ListPriceResearch.Count - 1;

                    price = ListPriceResearch[currentPriceIndex].Price;
                }

                return price;
            }
        }

        #endregion

        #region Methods

        public bool isValid()
        {
            var valid = true;

            if (string.IsNullOrEmpty(Description))
            {
                valid = false;
            }

            return valid;
        }

        public bool ValidateBeforeDelete(/*List<Product> listProducts*/)
        {
            var isValid = true;

            //foreach (var product in ListProduct)
            //{
            //    int quant = product.ListMaterial.Where(x => x.Id == Id).Count();
            //}

            return isValid;
        }

        public void genereteCode()
        {
            CodMaterial = string.Format("MAT{0}", Utils.GereneteRandomCode());
        }

        #endregion
    }
}
