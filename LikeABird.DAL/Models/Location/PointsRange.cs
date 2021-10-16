using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Location {
    public class PointsRange {
        public DeliveryPoint Point1 { get; set; }
        public DeliveryPoint Point2 { get; set; }
        public long Range { get; set; }
    }
}
