using System;
using System.Collections.Generic;

#nullable disable

namespace car_rental_api.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public long Mobileno { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public byte? MembershipTypeId { get; set; }
        public byte? Roles { get; set; }
        public string Membershipstatus { get; set; }

        public virtual MembershipType MembershipType { get; set; }
        public virtual Role RolesNavigation { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
