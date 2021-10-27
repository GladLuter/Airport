using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using LikeABird.IIL;
using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace LikeABird.ALL.Repositories {
    public abstract class ApplicationModel<DO, CurObj> : IDataObjectMethods<CurObj>
        where DO : IDataObject<DO>
        where CurObj : ApplicationModel<DO, CurObj> {
        protected IMapper DataMapper;//{ get; set; }
        protected ApplicationModel(IMapper CurMapper) {
            DataMapper = CurMapper;
        }
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public IDataObject<DO> DataObject { get; set; }

        protected virtual void MapItBack(CurObj AnotherObject = null) {
            DataMapper.Map<CurObj, DO>(AnotherObject ?? GetThis(), DataObject.CurrentObject);
        }
        protected abstract CurObj GetThis();

        public virtual Task DeleteAsync(int? id) {
            return DataObject.CurrentObject.DeleteAsync(id);
        }
        public virtual Task InsertAsync(CurObj obj) {
            var AnotherObject_DO = DataObject.CurrentObject.GetNewObj();
            DataMapper.Map<CurObj, DO>(obj, AnotherObject_DO);
            return DataObject.CurrentObject.InsertAsync(AnotherObject_DO);
        }
        public virtual bool Save() {
            MapItBack();
            return DataObject.CurrentObject.Save();
        }
        public virtual Task<CurObj> SelectByIdAsync(int? id) {
            var Task_DO = DataObject.CurrentObject.SelectByIdAsync(id);
            return Task.Factory.StartNew<CurObj>(() => SelectByIdAsync(Task_DO));
        }
        private CurObj SelectByIdAsync(Task<DO> task_) {
            CurObj Answer = GetNewObj();
            DataMapper.Map<DO, CurObj>(task_.Result, Answer);
            return Answer;
        }
        //public static CurObj SelectByIdAsync(int? id, IDataObject<DO> DataObj) {

        //}
        //public abstract Task<CurObj> SelectByIdAsync(int id, params Expression<Func<CurObj, object>>[] includes);
        public virtual Task UpdateAsync(CurObj obj) {          
            var AnotherObject_DO = DataObject.CurrentObject.GetNewObj();
            DataMapper.Map<CurObj, DO>(obj, AnotherObject_DO);
            return AnotherObject_DO.UpdateAsync(AnotherObject_DO);
        }

        public abstract CurObj GetNewObj(CurObj obj);

        public CurObj GetNewObj() {
            return GetNewObj(null);
        }



        //protected ApplicationModel(T incDB) {
        //    DB = incDB;
        //}

        //public virtual async Task DeleteAsync(int? id) {
        //    T deleted = await SelectByIdAsync(id);

        //    if (deleted != null)

        //        DB.Set<T>().Remove(deleted);
        //}



        //public virtual async Task<IEnumerable<T>> SelectAllAsync() {
        //    return await Db.Set<T>().ToListAsync();
        //}



        //public virtual async Task<IEnumerable<T>> SelectAllAsync(Expression<Func<T, bool>> predicate) {
        //    return await Db.Set<T>().Where(predicate).ToListAsync();
        //}



        //public virtual async Task<T> SelectByIdAsync(int? id) {
        //    return await Db.Set<T>().FindAsync(id);
        //}


        //public async Task<T> SelectByIdAsync(int id, params Expression<Func<T, object>>[] includes) {
        //    if (includes != null && includes.Length > 0)
        //        includes.ToList().ForEach(y => Db.Set<T>().Include(y));

        //    return await Db.Set<T>().FirstAsync(x => x.Id == id);
        //}

        //public virtual async Task InsertAsync(T user) {
        //    await Db.Set<T>().AddAsync(user);
        //}



        //public virtual async Task UpdateAsync(T user) {
        //    await Task.Run(() => Db.Entry(user).State = EntityState.Modified);
        //}
        //private static MapperConfiguration mapperConfig = new MapperConfiguration(mc =>
        //{
        //    mc.AddProfile(new DAL_to_BLL());
        //});
        //public static IMapper mapper = mapperConfig.CreateMapper();       
        //public static void ValidateMapping() {
        //    // only during development, validate your mappings; remove it before release
        //    mapperConfig.AssertConfigurationIsValid();
        //}
        //public static ApplicationContext DBConnection = new ApplicationContext(new DbContextOptions<ApplicationContext>());

    }
}
