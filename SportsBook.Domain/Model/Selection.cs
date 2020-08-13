using SportsBook.Domain.Enum;
using SportsBook.Domain.SeedWork;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBook.Domain.Model
{
    [Table("Selection", Schema = "dbo")]
    public class Selection: IEntity
    {
        public Selection()
        {
            Outcome = SelectionOutcome.Void;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public decimal Price { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        public SelectionOutcome Outcome { get; set; }
    }
}
