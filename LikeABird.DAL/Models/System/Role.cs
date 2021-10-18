using LikeABird.DAL.Models.Earnings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.System {
    public class Role : BaseModel {
        public string Name { get; set; }
        public bool Employee { get; set; }
        public virtual ICollection<EmployeePermition> Permitions { get; set; }
        public virtual ICollection<Discount> Discounts { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<EmployeePermition> EmployeePermitions { get; set; }
    }
}
