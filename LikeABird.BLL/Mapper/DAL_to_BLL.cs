using AutoMapper;
using LikeABird.BLL.Models.System;
using LikeABird.DAL.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.BLL.Mapper {
    public class DAL_to_BLL : Profile {
        public DAL_to_BLL() {
            CreateMap<BL_User, User>().MaxDepth(1)
                .ForMember(dto => dto.UserOperations, tt => tt.Ignore())
                .ForMember(dto => dto.Tickets, tt => tt.Ignore())
                .ReverseMap();
            CreateMap<BL_Role, Role>().MaxDepth(1).ForMember(dto => dto.Discounts, tt => tt.Ignore()).ReverseMap();
            CreateMap<BL_EmployeePermition, EmployeePermition>().MaxDepth(1).ReverseMap();
        }
    }
}
