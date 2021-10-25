using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Resource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Resource {
    
    public class AirplaneModel : BaseModel<AirplaneModel>, ITransportModel, ITransportCargo, ITransportPassenger {
        public string Name { get; set; }
        public string Number { get; set; }     
        public long Range { get; set; }
        public long Speed { get; set; }
        public long Cargo { get; set; }
        [NotMapped]
        public Seat[]? Seat { get; set; }
        private string SeatJson {
            get { return JsonConvert.SerializeObject(Seat); }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    Seat = null;
                else
                    Seat = JsonConvert.DeserializeObject<Seat[]>(value);
            }
        }
        public short Qty_EmergencyExit { get; set; }
        public short Qty_WC { get; set; }
        //public float Wingspan { get; set; }
        public virtual ICollection<Airplane> Airplanes { get; set; }
        public AirplaneModel(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
    }
}
