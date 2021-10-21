using AutoMapper;
using LikeABird.ALL.Repositories.System;
using LikeABird.DAL.EF;
using LikeABird.DAL.Models.System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.BLL.Mapper {
    public class DAL_to_ALL : Profile {
        public DAL_to_ALL() {
            CreateMap<AO_User, User>().MaxDepth(1)
                .ForMember(dto => dto.UserOperations, tt => tt.Ignore())
                .ForMember(dto => dto.Tickets, tt => tt.Ignore())
                .ReverseMap();
            CreateMap<AO_Role, Role>().MaxDepth(1).ForMember(dto => dto.Discounts, tt => tt.Ignore()).ReverseMap();
            CreateMap<AO_EmployeePermition, EmployeePermition>().MaxDepth(1).ReverseMap();
        }
        public static void AddMapper(IServiceCollection services) {
            services.AddAutoMapper(c => c.AddProfile<DAL_to_ALL>(), typeof(DAL_to_ALL));
        }
        public static void AddDbContext(IServiceCollection services) {
            ApplicationContext.AddDbContext(services);
        }
    }
}
