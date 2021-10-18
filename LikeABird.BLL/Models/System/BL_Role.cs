//using LikeABird.BLL.Models.Earnings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.BLL.Models.System {
    public class BL_Role : BaseModel {
        public string Name { get; set; }
        public bool Employee { get; set; }
        public virtual ICollection<BL_EmployeePermition> Permitions { get; set; }
        //public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<BL_User> Users { get; set; }
        public virtual ICollection<BL_EmployeePermition> EmployeePermitions { get; set; }
    }
}
