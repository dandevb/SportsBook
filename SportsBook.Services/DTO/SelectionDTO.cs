using SportsBook.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace SportsBook.Services.DTO
{
    public class SelectionDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public SelectionOutcome Outcome { get; set; }

        //Navigation properties & foreign keys
        public int EventId { get; set; }

        public int MarketId { get; set; }
    }
}
