using LikeABird.DAL.Models.Logistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Earnings {
    public class UserOperations {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public double Money { get; set; }
        //public Discount Discount { get; set; }
        public Transfer Transfer { get; set; }
    }
}
