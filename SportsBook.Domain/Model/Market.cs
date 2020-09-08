using SportsBook.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SportsBook.Domain.Model
{
    [Table("Market", Schema = "dbo")]
    public class Market: IEntity
    {
        [Key]
        [Column("MarketId")]
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
            set
            {
                if (String.IsNullOrWhiteSpace(DisplayName))
                {
                    DisplayName = Name;
                }
                else
                {
                    DisplayName = value;
                }
            }
        }

        [DefaultValue(false)]
        public bool Active { get; set; }

        [DefaultValue(0)]
        public int Order { get; set; }

        [DefaultValue(1)]
        public int Schema { get; set; }

        [DefaultValue(1)]
        public int Columns { get; set; }


        //Navigation properties & foreign keys
        public int EventForeignKey { get; set; }

        public virtual Event Event { get; set; }

        public virtual List<Selection> SelectionList { get; set; }

        //Methods
        public void CheckActive()
        {
            if (SelectionList == null || !SelectionList.Any() || SelectionList.Count(x => x.Active == true) == 0)
            {
                this.Active = false;
            }
        }
    }
}
