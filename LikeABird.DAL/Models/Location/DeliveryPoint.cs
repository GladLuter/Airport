using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Location {
    public class DeliveryPoint : BaseModel {
        public Country Country { get; set; }
        public string City { get; set; }
    }
}
