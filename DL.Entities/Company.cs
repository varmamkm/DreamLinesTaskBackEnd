using System;
using System.Collections.Generic;
using System.Text;

namespace DL.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<Trip> trips { get; set; }
    }
}
