using System;
using System.Collections.Generic;

#nullable disable

namespace GC_Car_Dealership.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public string Transmission { get; set; }
        public string Image { get; set; }
    }
}
