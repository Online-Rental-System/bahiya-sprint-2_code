using System;
using System.Collections.Generic;

#nullable disable

namespace car_rental_api.Models
{
    public partial class MembershipType
    {
        public MembershipType()
        {
            Users = new HashSet<User>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
