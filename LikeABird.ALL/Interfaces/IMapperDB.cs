using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.ALL.Interfaces {
    public interface IMapperDB<T> where T : class {
        public T CurrentObject { get; set; }
    }
}
