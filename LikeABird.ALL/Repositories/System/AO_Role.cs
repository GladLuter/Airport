//using LikeABird.BLL.Repositories.Earnings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.ALL.Repositories.System {
    public class AO_Role : ApplicationModel {
        public string Name { get; set; }
        public bool Employee { get; set; }
        public virtual ICollection<AO_EmployeePermition> Permitions { get; set; }
        //public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<AO_User> Users { get; set; }
        public virtual ICollection<AO_EmployeePermition> EmployeePermitions { get; set; }
    }
}
