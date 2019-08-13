using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Entities
{
    public class Trip
    {
        public Guid Id { get; set; }

        public int CompanyId { get; set; }

        public int ShipId { get; set; }

        public int CabinTypeId { get; set; }

        public bool IsFlightIncluded { get; set; }

        public DateTime DapartureDate { get; set; }

        public List<Route> Routes { get; set; }

        public virtual Company Company { get; set; }

        public virtual Ship Ship { get; set; }

        public virtual CabinType CabinType { get; set; }

    }

    public class Route
    {
        public int Day { get; set; }

        public int PortId { get; set; }

        public Guid TripId { get; set; }

        public virtual Trip Trip { get; set; }

        public virtual Port Port { get; set; }
    }
}
