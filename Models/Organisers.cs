using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace powerplatformevents.Models
{
    public partial class Organisers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Role { get; set; }
        public int EventId { get; set; }
        public int SpeakerId { get; set; }

        public Events Event { get; set; }
        public Speakers Speaker { get; set; }
    }
}
