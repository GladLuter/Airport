using LikeABird.DAL.Models.Resource;
using LikeABird.DAL.Models.System;
using LikeABird.DAL.Models.Logistic;
using LikeABird.DAL.Models.Location;
using LikeABird.DAL.Models.Earnings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeABird.DAL.EF.Configurations;
using LikeABird.DAL.Interfaces;
using LikeABird.DAL.EF.Properties;
using Microsoft.Extensions.DependencyInjection;

namespace LikeABird.DAL.EF {
    public class DataContext : DbContext, IDataContext {
        
        #region System
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeePermition> EmployeePermitions { get; set; }
        #endregion
        
        #region Resource
        //public DbSet<Transport> Transports { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<AirplaneModel> AirplaneModels { get; set; }
        #endregion

        #region Logistic
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        #endregion

        #region Location
        public DbSet<Country> Countrys { get; set; }
        public DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        public DbSet<PointsRange> PointsRanges { get; set; }
        #endregion

        #region Earnings
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<UserOperation> UserOperations { get; set; }
        #endregion

        public DataContext(DbContextOptions<DataContext> options) : base(options) {
            if (Database.EnsureCreated()) {
                DataInitialization.Initialize(this);
            }             
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //var ConnctionInfo = DB.GetDBInfo();
            //optionsBuilder.UseSqlServer(ConnctionInfo.ConnectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ConfigAirplane());
            modelBuilder.ApplyConfiguration(new ConfigAirplaneModel());
            modelBuilder.ApplyConfiguration(new ConfigCountry());
            modelBuilder.ApplyConfiguration(new ConfigDeliveryPoint());
            modelBuilder.ApplyConfiguration(new ConfigDiscount());
            modelBuilder.ApplyConfiguration(new ConfigEmployeePermition());
            modelBuilder.ApplyConfiguration(new ConfigPointsRange());
            modelBuilder.ApplyConfiguration(new ConfigPrice());
            modelBuilder.ApplyConfiguration(new ConfigRole());
            modelBuilder.ApplyConfiguration(new ConfigService());
            modelBuilder.ApplyConfiguration(new ConfigTicket());
            modelBuilder.ApplyConfiguration(new ConfigTransfer());
            modelBuilder.ApplyConfiguration(new ConfigUser());
            modelBuilder.ApplyConfiguration(new ConfigUserOperation());
        }
        public static void AddDbContext<T>(T services) where T: IServiceCollection {
            var ConnctionInfo = DB.GetDBInfo();
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(ConnctionInfo.ConnectionStrings));
        }
    }
}
