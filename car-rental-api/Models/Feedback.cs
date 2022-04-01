using System;
using System.Collections.Generic;

#nullable disable

namespace car_rental_api.Models
{
    public partial class Feedback
    {

        public int Id { get; set; }
        public int? UsersId { get; set; }
        public string Feedback1 { get; set; }

        public virtual User Users { get; set; }
    }
}
