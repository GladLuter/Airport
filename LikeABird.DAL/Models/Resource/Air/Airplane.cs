using LikeABird.DAL.EF;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.Resource {

  
    public class Airplane : Transport<Airplane> {
        public AirplaneModel Model { get; set; }
        //public int ModelId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public Airplane(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
        public Airplane() : this(null) { }
        public override Airplane GetNewObj(Airplane obj) {
            if (obj is null) {
                return new(Db);
            } else {
                return new(obj.Db);
            }
        }
    }
}
