using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.IIL;
public interface IDataObjectMethods<T>
{
    public abstract bool Save();
    public abstract Task<T> SelectByIdAsync(int? id);

    public abstract Task InsertAsync(T obj);

    public abstract Task UpdateAsync(T obj);

    public abstract Task DeleteAsync(int? id);
    //public abstract T GetNewObj(T obj);
    //public abstract T GetNewObj();

    //public abstract Task<T> SelectByIdAsync(int id, params Expression<Func<T, object>>[] includes);
}

