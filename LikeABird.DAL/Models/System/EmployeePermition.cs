using LikeABird.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.Models.System {
    public class EmployeePermition : BaseModel<EmployeePermition> {
        public Role Role { get; set; }
        public bool EditLocation { get; set; }
        public bool EditTransport { get; set; }
        public bool EditLogistic { get; set; }
        public bool EditService { get; set; }
        public bool EditPrice { get; set; }
        public bool EditRole { get; set; }
        public EmployeePermition(IDataContext incDb) : base(incDb) {
            CurrentObject = this;
        }
    }
}
