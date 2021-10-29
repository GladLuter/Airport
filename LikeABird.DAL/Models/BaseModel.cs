using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LikeABird.DAL.Interfaces;
using LikeABird.IIL;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using LikeABird.DAL.EF;

namespace LikeABird.DAL.Models {
    public abstract class BaseModel<T> : IDataObject<T> where T : BaseModel<T> {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        private T this_;
        [NotMapped]
        public virtual T CurrentObject {
            get {
                if (this_ is null)
                    this_ = (T)this;
                return this_;
            }
            set { this_ = value; }
        }
        [NotMapped]
        private IDataContext db;
        [NotMapped]
        protected IDataContext Db { 
            get {
                if (db is null)
                    db = DataContext.DBConnection;
                return db;
            } 
            set { db = value; } 
        }
        //protected BaseModel(IDataContext incDb) {
        //    SetCurrentDB(incDb);
        //}

        public virtual bool Save() {
            Task task = UpdateAsync(CurrentObject);
            task.Wait();
            return task.IsCompleted && !task.IsFaulted;
        }
        public virtual async Task<T> SelectByIdAsync(int? id) {
            var result = await Db.Set<T>().FindAsync(id);
            result.InitializeFilds(Db);
            return result;
        }
        public virtual async Task InsertAsync(T obj) {
            await Db.Set<T>().AddAsync(obj);
        }
        public virtual async Task UpdateAsync(T obj) {
            await Task.Run(() => Db.Entry(obj).State = EntityState.Modified);
        }
        public virtual async Task DeleteAsync(int? id) {
            T forDelete = await SelectByIdAsync(id);
            if (forDelete != null)
                Db.Set<T>().Remove(forDelete);
        }

        protected virtual void InitializeFilds(IDataContext inDB) {

        }
        //public abstract T GetNewObj(T obj);
        ////protected abstract T GetThis();

        //public T GetNewObj() {
        //    return GetNewObj(null);
        //}
        //public abstract Task<T> SelectByIdAsync(int id, params Expression<Func<T, object>>[] includes);
    }
}
