using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    public class Rent
    {
        public string RentID { get; set; }

        public string EmployeeID { get; set; }

        public string CarID { get; set; }

        public string ClientID { get; set; }

        public DateTime OutDate { get; set; }

        public DateTime InDate { get; set; }

        public int Duration { get; set; }

        public decimal Prize { get; set; }
    }
}
