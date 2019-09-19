using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace powerplatformevents.Models
{
    public partial class Events
    {
        public Events()
        {
            Organisers = new HashSet<Organisers>();
            Participants = new HashSet<Participants>();
            Sessions = new HashSet<Sessions>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string MapUrl { get; set; }
        public int? ParticipantCount { get; set; }

        public ICollection<Organisers> Organisers { get; set; }
        public ICollection<Participants> Participants { get; set; }
        public ICollection<Sessions> Sessions { get; set; }
    }
}
