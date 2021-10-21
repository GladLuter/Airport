using LikeABird.DAL.Models;
using LikeABird.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace LikeABird.BLL.Services {
    public abstract class BaseService<TBlEntity, TDalEntity>: IDisposable where TBlEntity : class where TDalEntity : BaseModel {
        protected readonly IUnitOfWork UnitOfWork;
        private static readonly IMapper Mapper_;

        protected BaseService(IUnitOfWork unitOfWork) {
            UnitOfWork = unitOfWork;
        }

        private bool _isDisposed;

        protected void Dispose(bool disposing) {
            if (_isDisposed)
                return;

            if (disposing) {
                UnitOfWork.Dispose();
            }
            _isDisposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static TDalEntity ToDalEntity(TBlEntity blEntity) {
            return Mapper_.Map<TBlEntity, TDalEntity>(blEntity);
        }

        public static IEnumerable<TDalEntity> ToDalEntity(IEnumerable<TBlEntity> blEntity) {
            return Mapper_.Map<IEnumerable<TBlEntity>, IEnumerable<TDalEntity>>(blEntity);
        }

        public static TBlEntity ToBlEntity(TDalEntity dalEntity) {
            return Mapper_.Map<TDalEntity, TBlEntity>(dalEntity);
        }

        public static IEnumerable<TBlEntity> ToBlEntity(IEnumerable<TDalEntity> dalEntity) {
            return Mapper_.Map<IEnumerable<TDalEntity>, IEnumerable<TBlEntity>>(dalEntity);
        }
    }
}
