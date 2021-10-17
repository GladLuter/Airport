using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Location {
    public class Country : BaseModel {
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public virtual ICollection<DeliveryPoint> DeliveryPoints { get; set; }
    }
}
