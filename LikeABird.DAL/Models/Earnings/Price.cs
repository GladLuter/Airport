using LikeABird.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Earnings {
    public class Price : BaseModel<Price> {
        public Service Service { get; set; }
        public long? RangeStart { get; set; }
        public long? RangeEnd { get; set; }
        public double Amount { get; set; }
        public Price(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
    }
}
