using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Earnings;
using LikeABird.DAL.Models.Logistic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.System {
    public class User : BaseModel<User> {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MainEmail { get; set; }
        public Role UserRole { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserOperation> UserOperations { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public User(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }

    }
}
