using System.ComponentModel.DataAnnotations;

namespace SportsBook.Services.DTO
{
    public class SportEventDTO
    {
        [Required]
        public int SportId { get; set; }

        [Required]
        public int EventId { get; set; }
    }
}