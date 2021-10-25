using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Logistic;
using LikeABird.DAL.Models.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Earnings {
    public class UserOperation : BaseModel<UserOperation> {
        public User User { get; set; }
        public DateTime Date { get; set; }
        public double Money { get; set; }
        //public Discount Discount { get; set; }
        public Transfer Transfer { get; set; }
        public UserOperation(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
    }
}
