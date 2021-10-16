using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models {
    
    public class AirplaneModel : ITransportModel, ITransportCargo, ITransportPassenger {
        public string Name { get; set; }
        public short Number { get; set; }     
        public long Range { get; set; }
        public long Speed { get; set; }
        public long Cargo { get; set; }
        public Seat[] Seat { get; set; }  
        public short Qty_EmergencyExit { get; set; }
        public short Qty_WC { get; set; }
        //public float Wingspan { get; set; }
      
    }
}
