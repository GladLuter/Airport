using LikeABird.DAL.EF;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Earnings;
using LikeABird.DAL.Models.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Logistic {
    public class Transfer : BaseModel<Transfer> {
        public Service Service { get; set; }
        public PointsRange PointsRange { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<UserOperation> UserOperations { get; set; }
        public Transfer(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
        public Transfer() : this(null) { }
        public override Transfer GetNewObj(Transfer obj) {
            if (obj is null) {
                return new(Db);
            } else {
                return new(obj.Db);
            }
        }
    }
}
