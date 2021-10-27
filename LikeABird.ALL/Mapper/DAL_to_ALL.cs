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
using AutoMapper;

namespace LikeABird.ALL.Mapper {
    public class DAL_to_ALL : Profile {
        public DAL_to_ALL() {

            //ShouldMapProperty = propertyInfo => true;
            //ShouldMapField = fieldInfo => true;
            //ShouldMapProperty = smp => smp.GetSetMethod(true).IsPublic
            //|| smp.GetSetMethod(true).IsPrivate
            //|| smp.GetSetMethod(true).IsHideBySig
            //|| smp.GetSetMethod(true).IsFamily
            //|| smp.GetSetMethod(true).IsFamilyAndAssembly
            //|| smp.GetSetMethod(true).IsFamilyOrAssembly
            //|| smp.GetSetMethod(true).IsAbstract;

            CreateMap<AO_User<User>, User>().MaxDepth(1)
                .ForMember(dal => dal.UserOperations, m => m.Ignore())
                .ForMember(dal => dal.Tickets, m => m.Ignore());
            CreateMap<User, AO_User<User>>().MaxDepth(1)
                //.AfterMap((dal, all) => all.DataObject = dal.CurrentObject);
                .ForMember(ao => ao.DataObject, m => m.MapFrom(dal => dal.CurrentObject))
                ;//.ConstructUsing(tt => new AO_User<User>());
            //.ForMember(ao => ao.DataObject, GetIt());
            CreateMap<AO_Role<Role>, Role>().MaxDepth(1).ForMember(dto => dto.Discounts, tt => tt.Ignore()).ReverseMap();
            CreateMap<AO_EmployeePermition<EmployeePermition>, EmployeePermition>().MaxDepth(1).ReverseMap();
        }
        public static void AddMapper(IServiceCollection services) {
            services.AddAutoMapper(c => c.AddProfile<DAL_to_ALL>(), typeof(DAL_to_ALL));
        }
        public static void AddDbContext(IServiceCollection services) {
            DataContext.AddDbContext(services);
        }
        private DAL_to_ALL GetIt() {
            return this;
        }
        //public void MapItBack(dynamic obj) {
        //    map;
        //}
    }
}
