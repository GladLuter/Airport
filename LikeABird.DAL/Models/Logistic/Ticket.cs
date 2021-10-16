using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Logistic {
    class Ticket {
        public int Id { get; set; }
        public User User { get; set; }
        public Transport Transport { get; set; }
        public Seat Seat { get; set; }
    }
}
