
using System;
using Microsoft.EntityFrameworkCore;
using LikeABird.DAL.EF;
using LikeABird.DAL.Models.System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using LikeABird.ALL.Mapper;
using LikeABird.ALL.Repositories.System;
using LikeABird.DAL.EF.Properties;

namespace ConsoleAppDevTst {
    class Program {
        static void Main(string[] args) {
            //Console.WriteLine("Hello World!");
            //string connection = "Data Source=R4489;Initial Catalog=LikeABird;Integrated Security=True";
            var DBContext = new DbContextOptions<DataContext>();

            using var db = new DataContext(DBContext);
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
            AO_User AO_User_ = new AO_User();
            mapper.Map<User, AO_User>(User, AO_User_);
            mapper.Map<AO_User, User>(AO_User_, User);
            Console.WriteLine($"AO_User - {AO_User_.LastName}");
            Console.WriteLine($"Change BL_User and relust is:");
            AO_User_.LastName += "1";
            Console.WriteLine($"AO_User - {AO_User_.LastName}");
            Console.WriteLine($"User - {User.LastName}");
            //Console.WriteLine($"Mapping back BL_User to User and relust is:");
            //User = mapper.Map<User>(AO_User);
            //Console.WriteLine($"User - {User.LastName}");
            //db.Users.Update(User);

        }
    }
}
