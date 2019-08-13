using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Entities
{
    public class CabinType
    {
        public int Id { get; set; }
        public int ShipId { get; set; }
        public string Title { get; set; }
        public virtual Ship Ship { get; set; }

        public List<Trip> trips { get; set; }
    }
}
