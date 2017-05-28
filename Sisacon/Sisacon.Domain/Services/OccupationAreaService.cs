using Sisacon.Domain.Interfaces.Services;
using Sisacon.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sisacon.Domain.Interfaces;
using Sisacon.Domain.Interfaces.Repositories;

namespace Sisacon.Domain.Services
{
    public class OccupationAreaService : ServiceBase<OccupationArea>, IOccupationAreaService
    {
        private readonly IOccupationAreaRepository _repository;

        public OccupationAreaService(IOccupationAreaRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public List<OccupationArea> getOccupationAreas()
        {
            var occupationAreaList = new List<OccupationArea>();

            try
            {
                occupationAreaList = _repository.getOccupationAreas();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return occupationAreaList;
        }
    }
}
