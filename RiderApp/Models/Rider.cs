using System;
using System.Collections.Generic;

namespace RiderApp.Models
{
    public partial class Rider
    {
        public Rider()
        {
            Job = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<Job> Job { get; set; }
    }
}
