using LikeABird.DAL.Models.Resource;
using LikeABird.DAL.Models.System;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Logistic {
    public class Ticket : BaseModel {
        public User User { get; set; }
        public Transport Transport { get; set; }
        [NotMapped]
        public Seat? Seat { get; set; }
        private string SeatJson {
            get { return JsonConvert.SerializeObject(Seat); }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    Seat = null;
                else
                    Seat = JsonConvert.DeserializeObject<Seat>(value);
            }           
        }
        public Transfer Transfer { get; set; }
    }
}
