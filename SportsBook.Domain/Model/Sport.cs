using SportsBook.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsBook.Domain.Model
{
    [Table("Sport", Schema = "dbo")]
    public class Sport: IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("SportId")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string DisplayName { 
            get {
                if (String.IsNullOrWhiteSpace(DisplayName))
                {
                    return Name;
                }else
                {
                    return this.DisplayName;
                }
            } 
            set { DisplayName = value; } 
        }

        [StringLength(150)]
        public string Slug {
            get { return this.Slug.ToLower(); } 
            set { Slug = value.ToLower(); } 
        }

        [DefaultValue(0)]
        public int Order { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        public virtual List<SportEvent> SportEventList { get; set; }
    }
}
