using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Logistic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Location {
    public class PointsRange : BaseModel<PointsRange> {
        public DeliveryPoint Point1 { get; set; }
        public DeliveryPoint Point2 { get; set; }
        public long Range { get; set; }
        public PointsRange(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
        //public virtual ICollection<Transfer> Transfers { get; set; }
    }
}
