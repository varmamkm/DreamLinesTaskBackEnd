using DL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DL.Infrastructure.Repository
{
    public interface ICruiseRepository<T> where T : Company
    {       
        Task<List<Company>> GetCruiseLines();

        Task<List<Ship>> GetShips(int CompanyId);

        Task<List<CabinType>> GetCabinCategory(int shipId);

        Task<List<Port>> GetPorts();

        Task<Trip> CreateTrip(Trip obj);
    }
}
