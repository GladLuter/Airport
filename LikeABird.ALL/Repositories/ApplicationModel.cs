using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using LikeABird.BLL.Mapper;
using LikeABird.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace LikeABird.ALL.Repositories {
    public abstract class ApplicationModel {
        [Key]
        public int Id { get; set; }

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
