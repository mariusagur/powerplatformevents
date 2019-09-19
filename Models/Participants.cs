using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace powerplatformevents.Models
{
    public partial class Participants
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public int EventId { get; set; }

        public Events Event { get; set; }
    }
}
