using LikeABird.DAL.EF;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Logistic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Earnings {
    public enum ServiceType {
        Passenger,
        Cargo,
        Kitchen,
        DutyFree
    }
    public class Service : BaseModel<Service> {
        public string Name { get; set; }
        public ServiceType Type { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
        public Service(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
        public Service() : this(null) { }
        public override Service GetNewObj(Service obj) {
            if (obj is null) {
                return new(Db);
            } else {
                return new(obj.Db);
            }
        }
    }
}
