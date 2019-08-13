using DL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL.Infrastructure.Service
{
    public interface ICruiseService
    {
        Task<List<CompanyDTO>> GetCruiseLines();

        Task<List<ShipDTO>> GetShips(int companyId);

        Task<List<CabinTypeDTO>> GetCabinCategory(int shipId);

        Task<List<PortDTO>> GetPorts();

        Task<TripDTO> CreateTrip(TripDTO obj);
    }
}
