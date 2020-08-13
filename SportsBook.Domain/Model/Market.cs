using SportsBook.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportsBook.Domain.Model
{
    [Table("Market", Schema = "dbo")]
    public class Market: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(150)]
        public string DisplayName {
            get
            {
                if (String.IsNullOrWhiteSpace(DisplayName))
                {
                    return Name;
                }
                else
                {
                    return this.DisplayName;
                }
            }
            set { DisplayName = value; }
        }

        [DefaultValue(0)]
        public int Order { get; set; }

        [DefaultValue(1)]
        public int Schema { get; set; }

        [DefaultValue(1)]
        public int Columns { get; set; }

        public int EventForeignKey { get; set; }

        public Event Event { get; set; }

        [ForeignKey("MarketId")]
        public virtual List<Selection> SelectionList { get; set; }
    }
}
