using Helpers;
using Sisacon.Domain.Entities;
using Sisacon.Domain.ValueObjects;
using Sisacon.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sisacon.Domain.Enuns.UserType;

namespace Sisacon.Infra.Migrations
{
    class UserSeed
    {
        public static void seed(SisaconDbContext context)
        {
            var userHasvalue = context.User.Any();

            if(!userHasvalue)
            {
                var user = new User();

                user.RegistrationDate = DateTime.Now;
                user.Active = true;
                user.Email = "horrander@outlook.com";
                user.eUserType = eUserType.Admin;
                user.Password = Security.Encrypt("bravo13");
                user.ShowWellcomeMessage = false;

                if(user.isValid())
                {
                    context.User.Add(user);

                    context.SaveChanges();
                }
            }
        }
    }
}
