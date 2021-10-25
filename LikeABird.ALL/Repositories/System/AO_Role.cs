using AutoMapper;
using LikeABird.IIL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.ALL.Repositories.System {
    public class AO_Role<DO> : ApplicationModel<DO, AO_Role<DO>> where DO : IDataObject<DO> {
        public AO_Role(IMapper CurMapper) : base(CurMapper) {
        }
        public string Name { get; set; }
        public bool Employee { get; set; }

        protected override AO_Role<DO> GetThis() {
            return this;
        }

        //public virtual ICollection<AO_EmployeePermition> Permitions { get; set; }
        //public virtual ICollection<Discount> Discounts { get; set; }
        //public virtual ICollection<AO_User> Users { get; set; }
        //public virtual ICollection<AO_EmployeePermition> EmployeePermitions { get; set; }
    }
}
