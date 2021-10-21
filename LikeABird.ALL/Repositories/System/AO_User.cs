//using LikeABird.BLL.Models.Earnings;
//using LikeABird.BLL.Models.Logistic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeABird.DAL.Models.System;

namespace LikeABird.ALL.Repositories.System {
    public class AO_User : ApplicationModel {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MainEmail { get; set; }
        public AO_Role UserRole { get; set; }
        public string Password { get; set; }
       // public virtual ICollection<UserOperation> UserOperations { get; set; }
        //public virtual ICollection<Ticket> Tickets { get; set; }
        //public BL_User GetByID(int ID) {
        //    var User = DBConnection.Users.FirstOrDefaultAsync<User>(u => u.Id == ID);
        //    var BL_User = mapper.Map<BL_User>(User);
        //    return BL_User;
        //}
    }
}
