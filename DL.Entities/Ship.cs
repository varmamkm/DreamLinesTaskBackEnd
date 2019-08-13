using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Entities
{
    public class Ship
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public List<CabinType> CabinTypes { get; set; }
        public List<Trip> trips { get; set; }
    }
}
