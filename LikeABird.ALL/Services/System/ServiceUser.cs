using LikeABird.BLL.Interfaces;
using LikeABird.BLL.Models.System;
using LikeABird.DAL.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.BLL.Services.System {
    public class ServiceUser : BaseService<BL_User, User>, IServiceUser {
        public async Task AddAsync(BL_User User_) {
            if (User_ == null || User_.Id <= 0 || User_.Name.Length == 0)
                throw new ArgumentException("Wrong user model");

            //User_.DateOfAddition = DateTime.Now;

            //await _gameRepository.InsertAsync(ToDalEntity(game));
            await UnitOfWork.SaveAsync();
        }

        public Task DeleteAsync(int id) {

            if (await GetAsync(id) != null)
                await _gameRepository.DeleteAsync(id);
            await UnitOfWork.SaveAsync();
        }

        public Task<IEnumerable<BL_User>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<BL_User> GetAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BL_Role>> GetRoleByUserAsync(int id) {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BL_User User_) {
            throw new NotImplementedException();
        }
    }
}
