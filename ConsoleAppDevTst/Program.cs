
using System;
using Microsoft.EntityFrameworkCore;
using LikeABird.DAL.EF;
using LikeABird.DAL.Models.System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using LikeABird.BLL.Mapper;
using LikeABird.BLL.Models.System;

namespace ConsoleAppDevTst {
    class Program {
        static void Main(string[] args) {
            //Console.WriteLine("Hello World!");
            //string connection = "Data Source=R4489;Initial Catalog=LikeABird;Integrated Security=True";
            var DBContext = new DbContextOptions<ApplicationContext>();

            using var db = new ApplicationContext(DBContext);
            db.SaveChanges();
            Console.WriteLine("DB created");

            //IServiceCollection services;
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DAL_to_ALL());
            });

            // only during development, validate your mappings; remove it before release
            mapperConfig.AssertConfigurationIsValid();
            var mapper = mapperConfig.CreateMapper();

            var User = db.Users.FirstOrDefaultAsync<User>(u => u.Id == 1).Result;

            //AutoMapper.Mapper.Equals

            Console.WriteLine($"User - {User.LastName}");
            var BL_User = mapper.Map<BL_User>(User);
            Console.WriteLine($"BL_User - {BL_User.LastName}");
            Console.WriteLine($"Change BL_User and relust is:");
            BL_User.LastName += "1";
            Console.WriteLine($"BL_User - {BL_User.LastName}");
            Console.WriteLine($"User - {User.LastName}");
            Console.WriteLine($"Mapping back BL_User to User and relust is:");
            User = mapper.Map<User>(BL_User);
            Console.WriteLine($"User - {User.LastName}");
            db.Users.Update(User);

        }
    }
}
