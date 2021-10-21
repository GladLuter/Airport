using LikeABird.BLL.Mapper;
using LikeABird.BLL.Models.System;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LikeABird.WebAPI.Injection {
    public class InjectionResolver {
        public static void ConfigurateInjections(IServiceCollection service) {

            DAL_to_ALL.AddDbContext(service);
            DAL_to_ALL.AddMapper(service);

            service.AddScoped<BL_User>();
        }
    }
}
