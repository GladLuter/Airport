using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.ALL.Repositories.System {
    public class AO_EmployeePermition : ApplicationModel {
        public AO_Role Role { get; set; }
        public bool EditLocation { get; set; }
        public bool EditTransport { get; set; }
        public bool EditLogistic { get; set; }
        public bool EditService { get; set; }
        public bool EditPrice { get; set; }
        public bool EditRole { get; set; }
    }
}
