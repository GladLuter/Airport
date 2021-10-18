//using LikeABird.BLL.Models.Earnings;
//using LikeABird.BLL.Models.Logistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.BLL.Models.System {
    public class BL_User : BaseModel {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MainEmail { get; set; }
        public BL_Role UserRole { get; set; }
        public string Password { get; set; }
       // public virtual ICollection<UserOperation> UserOperations { get; set; }
        //public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
