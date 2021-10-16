using LikeABird.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Earnings {
    public enum ServiceType {
        Passenger,
        Cargo,
        Kitchen,
        DutyFree
    }
    public class Service {
        public int Id { get; set; }
        public string Name { get; set; }
        public ServiceType Type { get; set; }

    }
}
