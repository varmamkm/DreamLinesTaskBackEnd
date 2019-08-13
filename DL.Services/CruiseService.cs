using DL.DTO;
using DL.Entities;
using DL.Infrastructure.Repository;
using DL.Infrastructure.Service;
using DL.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL.Services
{
    public class CruiseService<TCompany>: ICruiseService where TCompany : Company
    {
        private readonly ICruiseRepository<TCompany> cruiseRepository;

        public CruiseService(ICruiseRepository<TCompany> cruiseRepository)
        {
            this.cruiseRepository = cruiseRepository;
        }

        public async Task<List<CompanyDTO>> GetCruiseLines()
        {
            var result = await cruiseRepository.GetCruiseLines();

            return result.MapTo<List<CompanyDTO>>();
        }

        public async Task<List<ShipDTO>> GetShips(int companyId)
        {
            var result = await cruiseRepository.GetShips(companyId);

            return result.MapTo<List<ShipDTO>>();
        }

        public async Task<List<CabinTypeDTO>> GetCabinCategory(int shipId)
        {
            var result = await cruiseRepository.GetCabinCategory(shipId);

            return result.MapTo<List<CabinTypeDTO>>();
        }

        public async Task<List<PortDTO>> GetPorts()
        {
            var result = await cruiseRepository.GetPorts();

            return result.MapTo<List<PortDTO>>();
        }

        public async Task<TripDTO> CreateTrip(TripDTO obj)
        {
            var result = await cruiseRepository.CreateTrip(obj.MapTo<Trip>());

            return result.MapTo<TripDTO>();
        }
        


    }
}
