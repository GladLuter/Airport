using System;
using Microsoft.EntityFrameworkCore;
using LikeABird.DAL.EF;

namespace ConsoleAppDevTst {
    class Program {
        static void Main(string[] args) {
            //Console.WriteLine("Hello World!");
            //string connection = "Data Source=R4489;Initial Catalog=LikeABird;Integrated Security=True";
            var DBContext = new DbContextOptions<ApplicationContext>();

            using var db = new ApplicationContext(DBContext);
            db.SaveChanges();
            Console.WriteLine("Hello World!");
        }
    }
}
