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
                if (String.IsNullOrWhiteSpace(this.DisplayName))
                {
                    this.DisplayName = Name;
                }

                return this.DisplayName;
            }
            set {
                this.DisplayName = value;
            } 
        }

        [StringLength(150)]
        public string Slug {
            get { return this.Slug; }
            set { this.Slug = value.ToLower(); }
        }

        [DefaultValue(0)]
        public int Order { get; set; }

        [DefaultValue(false)]
        public bool Active { get; set; }

        //Navigation property
        public virtual List<SportEvent> SportEventList { get; set; }

        //Methods
        public void CheckActive()
        {
            if (SportEventList == null || SportEventList.Count == 0)
            {
                this.Active = false;
                return;
            }

            //Look for at least one event that is active
            foreach (var sportEvent in SportEventList)
            {
                if (sportEvent.Event.Active == true)
                {
                    return;
                }
            }
            this.Active = false; //Didn't find active events so we set the sport to false
        }
    }
}
