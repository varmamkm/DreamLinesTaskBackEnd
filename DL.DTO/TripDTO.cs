using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DL.DTO
{
    public class TripDTO
    {
        [Required]
        public int CompanyId { get; set; }

        [Required]
        public int ShipId { get; set; }

        [Required]
        public int CabinTypeId { get; set; }

        [Required]
        public DateTime DapartureDate { get; set; }

        public bool IsFlightIncluded { get; set; }

        public List<RouteDTO> Routes { get; set; }
    }

    public class RouteDTO
    {
        public int Day { get; set; }

        public int PortId { get; set; }
    }
}
