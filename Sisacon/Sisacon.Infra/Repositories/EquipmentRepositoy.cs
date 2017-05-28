using Sisacon.Domain.Entities;
using Sisacon.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sisacon.Infra.Repositories
{
    public class EquipmentRepositoy : RepositoryBase<Equipment>, IEquipmentRepository
    {
        public override void add(Equipment equipment)
        {
            try
            {
                Context.Equipment.Add(equipment);
                Context.User.Attach(equipment.User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Equipment> getByUserId(int userId)
        {
            try
            {
                return Context.Equipment.
                    Include("User").
                    Where(x => x.IdUser == userId && x.ExclusionDate == null).
                    ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetCount(int userId)
        {
            try
            {
                return Context.
                    Equipment.
                    Where(x => x.User.Id == userId && x.ExclusionDate == null).
                    Count();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
