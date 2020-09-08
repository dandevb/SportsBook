using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsBook.Services.DTO
{
    public class SportDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Slug { get; set; }

        public int Order { get; set; }

        public bool Active { get; set; }

        //Navigation property
        public virtual List<SportEventDTO> SportEventList { get; set; }
    }
}
