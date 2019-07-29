using System;
using System.Collections.Generic;

namespace RiderApp.Models
{
    public partial class Job
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int RiderId { get; set; }
        public int ReviewScore { get; set; }
        public string ReviewComment { get; set; }
        public DateTime CompletedAt { get; set; }

        public Rider Rider { get; set; }
    }
}
