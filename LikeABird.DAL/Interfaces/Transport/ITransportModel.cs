using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Interfaces {
    interface ITransportModel {
        public string Name { get; set; }
        public string Number { get; set; }
        public long Range { get; set; }
        public long Speed { get; set; }
    }
}
