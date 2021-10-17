using LikeABird.DAL.Models.Earnings;
using LikeABird.DAL.Models.Logistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.System {
    public class User : BaseModel {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MainEmail { get; set; }
        public Role UserRole { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserOperation> UserOperations { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
