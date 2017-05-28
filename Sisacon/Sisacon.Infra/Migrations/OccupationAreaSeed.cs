using Sisacon.Domain.ValueObjects;
using Sisacon.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sisacon.Infra.Migrations
{
    public class OccupationAreaSeed
    {
        public static void seed(SisaconDbContext context)
        {
            var occupationHasValue = context.OccupationArea.Any();

            if (!occupationHasValue)
            {
                var date = DateTime.Now;

                var listOccupationAreas = new List<OccupationArea>()
                {
                    new OccupationArea() { Description = "Pintura",  RegistrationDate = date},
                    new OccupationArea() { Description = "Marcenaria",  RegistrationDate = date },
                    new OccupationArea() { Description = "Serralheria",  RegistrationDate = date },
                    new OccupationArea() { Description = "Alimentos",  RegistrationDate = date },
                    new OccupationArea() { Description = "Bijouterias",  RegistrationDate = date },
                    new OccupationArea() { Description = "Decoração",  RegistrationDate = date },
                };

                context.OccupationArea.AddRange(listOccupationAreas);

                context.SaveChanges();
            }
        }
    }
}
