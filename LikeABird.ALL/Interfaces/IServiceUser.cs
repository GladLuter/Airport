using LikeABird.ALL.Repositories.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.ALL.Interfaces {
    public interface IServiceUser : IDisposable {
        Task AddAsync(AO_User User_);
        Task UpdateAsync(AO_User User_);
        Task<AO_User> GetAsync(int id);
        Task<IEnumerable<AO_Role>> GetRoleByUserAsync(int id);
        Task<IEnumerable<AO_User>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
