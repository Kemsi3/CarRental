using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarRental
{
    public class Rent
    {
        [Key]
        public Guid RentID { get; set; }

        public virtual string EmployeeID { get; set; }

        public virtual string CarID { get; set; }

        public virtual string ClientEmail { get; set; }

        public DateTime? OutDate { get; set; }

        public DateTime? InDate { get; set; }

        public int Duration { get; set; }

        public decimal Prize { get; set; }

        public DateTime? RentDate { get; set; }
    }
}
