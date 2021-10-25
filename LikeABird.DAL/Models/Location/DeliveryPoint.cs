using LikeABird.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Location {
    public class DeliveryPoint : BaseModel<DeliveryPoint> {
        public Country Country { get; set; }
        public string City { get; set; }
        public DeliveryPoint(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
    }
}
