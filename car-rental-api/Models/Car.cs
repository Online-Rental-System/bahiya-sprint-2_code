using System;
using System.Collections.Generic;

#nullable disable

namespace car_rental_api.Models
{
    public partial class Car
    {
        public Car()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string Model { get; set; }
        public string AvailabilityStatus { get; set; }
        public int? RentPrice { get; set; }
        public string Carstatus { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
