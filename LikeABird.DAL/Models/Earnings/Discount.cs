using LikeABird.DAL.Models.System;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.EF;

namespace LikeABird.DAL.Models.Earnings {
    public enum DiscountType {
        Amount,
        Percent
    }
    public class Discount: BaseModel<Discount> {
        public Service Service { get; set; }
        public Role UserRole { get; set; }
        public DiscountType Type { get; set; }
        public double Amount { get; set; }
        //public Discount(IDataContext incDb) : base(incDb) {
        //    CurrentObject = this;
        //}
        //public Discount() : this(null) { }
        //public override Discount GetNewObj(Discount obj) {
        //    if (obj is null) {
        //        return new(Db);
        //    } else {
        //        return new(obj.Db);
        //    }
        //}
    }
}
