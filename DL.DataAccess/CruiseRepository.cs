using DL.Entities;
using DL.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DL.DataAccess
{
    public class CruiseRepository : ICruiseRepository<Company>
    {
        protected DataContext context;

        public CruiseRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<List<Company>> GetCruiseLines()
        {
            return await context.Set<Company>()
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<List<Ship>> GetShips(int CompanyId)
        {
            return await context.Set<Ship>()
                .Where(i=>i.CompanyId==CompanyId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<CabinType>> GetCabinCategory(int shipId)
        {
            return await context.Set<CabinType>()
                .Where(i => i.ShipId == shipId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Port>> GetPorts()
        {
            return await context.Set<Port>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Trip> CreateTrip(Trip obj)
        {
            Guid guid = Guid.NewGuid();
            obj.Id = guid;
            context.Entry(obj).State = EntityState.Added;
            await context.SaveChangesAsync();
            foreach (var route in obj.Routes)
            {
                route.TripId = guid;
                context.Routes.Attach(route);
                context.Entry(route).State = EntityState.Added;
                await context.SaveChangesAsync();
            }
            return obj;
        }
    }
}
 