using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Earnings {
    class Price {
        public Service Service { get; set; }
        public long RangeStart { get; set; }
        public long RangeEnd { get; set; }
        public double Amount { get; set; }
    }
}
