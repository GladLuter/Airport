using AutoMapper;
using LikeABird.IIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.ALL.Repositories.System {
    public class AO_EmployeePermition<DO> : ApplicationModel<DO, AO_EmployeePermition<DO>> where DO : IDataObject<DO> {
        public AO_EmployeePermition(IMapper CurMapper) : base(CurMapper) {
        }
        //public AO_Role Role { get; set; }
        public bool EditLocation { get; set; }
        public bool EditTransport { get; set; }
        public bool EditLogistic { get; set; }
        public bool EditService { get; set; }
        public bool EditPrice { get; set; }
        public bool EditRole { get; set; }

        public override AO_EmployeePermition<DO> GetNewObj(AO_EmployeePermition<DO> obj) {
            if (obj is null) {
                return new(DataMapper);
            } else {
                return new(obj.DataMapper);
            }
        }

        protected override AO_EmployeePermition<DO> GetThis() {
            return this;
        }
    }
}
