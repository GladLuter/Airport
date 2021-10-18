using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Logistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Earnings {
    public enum ServiceType {
        Passenger,
        Cargo,
        Kitchen,
        DutyFree
    }
    public class Service : BaseModel {
        public string Name { get; set; }
        public ServiceType Type { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
