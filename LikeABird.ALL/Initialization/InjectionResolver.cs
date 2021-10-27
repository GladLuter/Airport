using LikeABird.ALL.Mapper;
using LikeABird.ALL.Repositories.System;
using LikeABird.DAL.EF;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.Models.System;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LikeABird.ALL.Initialization {
    public class InjectionResolver {
        public static void ConfigurateInjections(IServiceCollection service) {
          
            DAL_to_ALL.AddDbContext(service);
            DAL_to_ALL.AddMapper(service);
            service.AddScoped<IDataContext, DataContext>();
            //service.AddScoped<AO_User<User>>(tt => tt.);
            

            //service.AddScoped<BL_User>();
        }
    }
}
