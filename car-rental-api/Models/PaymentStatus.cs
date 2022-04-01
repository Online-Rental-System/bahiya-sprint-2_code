using System;
using System.Collections.Generic;

#nullable disable

namespace car_rental_api.Models
{
    public partial class PaymentStatus
    {
        public PaymentStatus()
        {
            Bookings = new HashSet<Booking>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
