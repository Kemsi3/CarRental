using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Windows.Media;


namespace CarRental
{
    public class Car
    {   
        [Key]
        public string CarID { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int ProductionYear { get; set; }

        public int Capacity { get; set; }

        public int HorsePower { get; set; }

        public string Color { get; set; }

        public int Doors { get; set; }

        public string Type { get; set; }

        public decimal Prize { get; set; }

        public bool Availability { get; set; }

        public int Odometer { get; set; }

        public Uri Uri { get; set; }


    }
}
