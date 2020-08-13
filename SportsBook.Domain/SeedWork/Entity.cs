using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBook.Domain.SeedWork
{
    public interface IEntity
    {
        int Id { get; set; }
        //public virtual int Id
        //{
        //    get
        //    {
        //        return _Id;
        //    }
        //    protected set
        //    {
        //        _Id = value;
        //    }
        //}
        //public override bool Equals(object obj)
        //{
        //    if (obj == null || !(obj is Entity))
        //        return false;

        //    if (Object.ReferenceEquals(this, obj))
        //        return true;

        //    if (this.GetType() != obj.GetType())
        //        return false;

        //    Entity item = (Entity)obj;

        //    if (item.IsTransient() || this.IsTransient())
        //        return false;
        //    else
        //        return item.Id == this.Id;
        //}
    }
}
