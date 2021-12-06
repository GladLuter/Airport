using LikeABird.DAL.EF;
using LikeABird.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Location;
public class Country : BaseModel<Country>
{
    public string NameFull { get; set; }
    public string NameShort { get; set; }
    public virtual ICollection<DeliveryPoint> DeliveryPoints { get; set; }
    //public Country(IDataContext incDb) : base(incDb) {
    //    CurrentObject = this;
    //}
    //public Country() : this(null) {}
    //public override Country GetNewObj(Country obj) {
    //    if (obj is null) {
    //        return new(Db);
    //    } else {
    //        return new(obj.Db);
    //    }
    //}
}

