using SportsBook.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SportsBook.Services
{
    public class EventDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public EventType EventType { get; set; }

        public EventStatusType Status { get; set; }

        [StringLength(150)]
        public string Slug { get; set; }

        public bool Active { get; set; }

        [Required]
        public int SportId { get; set; }

        //Navigation properties
        //public virtual List<SportEvent> SportEventList { get; set; }

        //public virtual List<Market> MarketList { get; set; }
    }
}