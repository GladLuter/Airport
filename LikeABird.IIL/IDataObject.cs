using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LikeABird.IIL {
    public interface IDataObject<T>: IDataObjectMethods<T> where T: IDataObject<T> {
        public T CurrentObject { get; set; }
    }
}
