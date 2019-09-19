using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace powerplatformevents.Models
{
    public partial class Speakers
    {
        public Speakers()
        {
            Organisers = new HashSet<Organisers>();
            Sessions = new HashSet<Sessions>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string TwitterAddress { get; set; }
        public string LinkedInProfile { get; set; }
        public string BlogUrl { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhoneNumber { get; set; }
        public bool? Mvp { get; set; }
        public string Aadid { get; set; }
        public string ProfilePhotoUrl { get; set; }

        public ICollection<Organisers> Organisers { get; set; }
        public ICollection<Sessions> Sessions { get; set; }
    }
}
