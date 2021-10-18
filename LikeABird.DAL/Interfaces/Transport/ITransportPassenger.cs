using LikeABird.DAL.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Interfaces {
   
    interface ITransportPassenger {
        public Seat[]? Seat { get; set; }
    }
}
