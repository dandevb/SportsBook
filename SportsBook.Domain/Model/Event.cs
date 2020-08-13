using SportsBook.Domain.Enums;
using SportsBook.Domain.SeedWork;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBook.Domain.Model
{
    [Table("Event", Schema = "dbo")]
    public class Event : IEntity
    {
        public Event()
        {
            EventType = EventType.Preplay;
            Status = EventStatusType.Preplay;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("EventId")]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public EventType EventType { get; set; }

        [DataType(DataType.Text)]
        public EventStatusType Status { get; set; }

        [StringLength(150)]
        [DataType(DataType.Url)]
        public string Slug
        {
            get { return this.Slug.ToLower(); }
            set { Slug = value.ToLower(); }
        }
        [DefaultValue(false)]
        public bool Active { get; set; }

        public virtual List<SportEvent> SportEventList { get; set; }

        public virtual List<Market> MarketList { get; set; }
    }
}
