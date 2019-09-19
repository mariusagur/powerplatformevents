using System.ComponentModel.DataAnnotations.Schema;

namespace powerplatformevents.Models
{
    public partial class Sessions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Prerequisites { get; set; }
        public string Audience { get; set; }
        public string Level { get; set; }
        public int? SpeakerId { get; set; }
        public int EventId { get; set; }
        public int Track { get; set; }
        public int Timeslot { get; set; }
        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }

        public Events Event { get; set; }
        public Speakers Speaker { get; set; }
    }
}
