using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SportsBook.Services.DTO
{
    public class MarketDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool Active { get; set; }

        public int Order { get; set; }
        public int Schema { get; set; }
        public int Columns { get; set; }

        [Required]
        public int EventForeignKey { get; set; }
    }
}
