using LikeABird.DAL.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models {

  
    public class Airplane : Transport {
        public AirplaneModel Model { get; set; }
    }
}
