using System.ComponentModel.DataAnnotations;

namespace SportsBook.Domain.Model
{
    public class SportEvent
    {
        [Required]
        public int SportId { get; set; }
        public virtual Sport Sport { get; set; }

        [Required]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
