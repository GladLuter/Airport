using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models {
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string MainEmail { get; set; }
        public Role UserRole { get; set; }
        public int Money { get; set; }
    }
}
