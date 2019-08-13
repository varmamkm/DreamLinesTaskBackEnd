using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Entities
{
    public class Port
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

        public List<Route> Routes { get; set; }
    }
}
