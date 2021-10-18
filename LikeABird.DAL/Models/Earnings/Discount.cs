using LikeABird.DAL.Models.System;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Earnings {
    public enum DiscountType {
        Amount,
        Percent
    }
    public class Discount: BaseModel {
        public Service Service { get; set; }
        public Role UserRole { get; set; }
        public DiscountType Type { get; set; }
        public double Amount { get; set; }

    }
}
