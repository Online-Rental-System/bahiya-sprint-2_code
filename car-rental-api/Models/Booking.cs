using System;
using System.Collections.Generic;

#nullable disable

namespace car_rental_api.Models
{
    public partial class Booking
    {
        public int Bookingid { get; set; }
        public int? CarsId { get; set; }
        public int? UserId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public byte? PaymentModeId { get; set; }
        public byte? PaymentStatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Bookingstatus { get; set; }

        public virtual Car Cars { get; set; }
        public virtual PaymentMode PaymentMode { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public virtual User User { get; set; }
    }
}
