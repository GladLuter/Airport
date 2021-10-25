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

namespace LikeABird.DAL.Models {
    public abstract class BaseModel<T> : IDataObject<T> where T : BaseModel<T> {
        [Key]
        public int Id { get; set; }
        [NotMapped]
        public virtual T CurrentObject { get; set; }
        [NotMapped]
        protected readonly IDataContext Db;
        protected BaseModel(IDataContext incDb){
            Db = incDb;
        }

        public virtual bool Save() {
            Task task = UpdateAsync(CurrentObject);
            task.Wait();
            return task.IsCompleted && !task.IsFaulted;
        }
        public virtual async Task<T> SelectByIdAsync(int? id) {
            return await Db.Set<T>().FindAsync(id);
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
        //public abstract Task<T> SelectByIdAsync(int id, params Expression<Func<T, object>>[] includes);
    }
}
