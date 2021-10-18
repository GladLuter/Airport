using LikeABird.DAL.Models.Earnings;
using LikeABird.DAL.Models.Location;
using LikeABird.DAL.Models.Resource;
using LikeABird.DAL.Models.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.EF {
    class DataInitialization {
        public static void Initialize(ApplicationContext context) {
            #region Role
            var RoleAdmin = new Role() { Employee = true, Name = "Admin"};
            var RoleClient = new Role() { Employee = false, Name = "Client" };
            var RoleVIP = new Role() { Employee = false, Name = "Client VIP" };
            context.Roles.AddRangeAsync(new Role[] { RoleAdmin, RoleClient, RoleVIP });
            #endregion

            var PermitionAdmin = new EmployeePermition() { Role = RoleAdmin, EditLocation = true, EditLogistic = true, EditPrice = true, EditRole = true, EditService = true, EditTransport = true };
            context.EmployeePermitions.AddAsync(PermitionAdmin);

            #region Users
            var UserAdmin = new User() { LastName = "Sleptsov", Name = "Evgenii", MainEmail = "Admin@mail.Mail", UserRole = RoleAdmin, Phone = "111111111", Password = "123" };
            var UserClient1 = new User() { LastName = "Pupkin", Name = "Vitaliy", MainEmail = "Client1@mail.Mail", UserRole = RoleClient, Phone = "2222", Password = "123" };
            var UserClient2 = new User() { LastName = "Sleptsov", Name = "Evgenii", MainEmail = "Client2@mail.Mail", UserRole = RoleClient, Phone = "123123123", Password = "123" };
            var UserClientVIP = new User() { LastName = "Sleptsov", Name = "Evgenii", MainEmail = "VIP@mail.Mail", UserRole = RoleVIP, Phone = "34234234234", Password = "123" };
            context.Users.AddRangeAsync(new User[] { UserAdmin, UserClient1, UserClient2, UserClientVIP });
            #endregion

            #region AirplaneModel

            var AirplaneModel_Boeing767_200 = new AirplaneModel() { 
                Name = "Boeng"
                ,Number = "767-200"
                ,Cargo = 142880
                ,Qty_EmergencyExit = 4
                ,Qty_WC = 1
                ,Range = 9400
                ,Speed = 851
                ,Seat = Transport.GetSeats(30, 4)
            };
            var AirplaneModel_Boeing767_200ER = new AirplaneModel() {
                Name = "Boeng"
                ,Number = "767-200ER"
                ,Cargo = 179170
                ,Qty_EmergencyExit = 6
                ,Qty_WC = 2
                ,Range = 12200
                ,Speed = 900
                ,Seat = Transport.GetSeats(24, 6)
            };
            var AirplaneModel_Boeing767_300 = new AirplaneModel() {
                Name = "Boeng"
                ,Number = "767-300"
                ,Cargo = 158760
                ,Qty_EmergencyExit = 2
                ,Qty_WC = 1
                ,Range = 9700
                ,Speed = 700
                ,Seat = Transport.GetSeats(28, 4)
            };
            var AirplaneModel_Boeing767_300ER = new AirplaneModel() {
                Name = "Boeng"
                ,Number = "767-300ER"
                ,Cargo = 186880
                ,Qty_EmergencyExit = 6
                ,Qty_WC = 2
                ,Range = 11305
                ,Speed = 870
                ,Seat = Transport.GetSeats(26, 6)
            };
            var AirplaneModel_Boeing767_300F = new AirplaneModel() {
                Name = "Boeng"
                ,Number = "767-300F"
                ,Cargo = 186880
                ,Qty_EmergencyExit = 6
                ,Qty_WC = 2
                ,Range = 6050
                ,Speed = 600
                ,Seat = Transport.GetSeats(36, 6)
            };
            var AirplaneModel_Boeing767_400ER = new AirplaneModel() {
                Name = "Boeng"
                ,Number = "767-400ER"
                ,Cargo = 204120
                ,Qty_EmergencyExit = 6
                ,Qty_WC = 4
                ,Range = 10450
                ,Speed = 950
                ,Seat = Transport.GetSeats(30, 6)
            };

            context.AirplaneModels.AddRangeAsync(new AirplaneModel[] { 
                AirplaneModel_Boeing767_200,
                AirplaneModel_Boeing767_200ER,
                AirplaneModel_Boeing767_300,
                AirplaneModel_Boeing767_300ER,
                AirplaneModel_Boeing767_300F,
                AirplaneModel_Boeing767_400ER
            });

            #endregion

            var Airplans_200 = AddAirplans(context, 5, AirplaneModel_Boeing767_200);
            var Airplans_200ER = AddAirplans(context, 7, AirplaneModel_Boeing767_200ER);
            var Airplans_300 = AddAirplans(context, 2, AirplaneModel_Boeing767_300);
            var Airplans_300ER = AddAirplans(context, 3, AirplaneModel_Boeing767_300ER);
            var Airplans_300F = AddAirplans(context, 4, AirplaneModel_Boeing767_300F);
            var Airplans_400ER = AddAirplans(context, 10, AirplaneModel_Boeing767_400ER);

            Country CountryUA = new Country() { NameFull = "Ukraine", NameShort = "UA" };
            Country CountryPL = new Country() { NameFull = "Polland", NameShort = "PL" };
            Country CountryTR = new Country() { NameFull = "Turkish", NameShort = "TR" };
            context.Countrys.AddRangeAsync(new Country[]{ CountryUA, CountryTR, CountryPL });

            DeliveryPoint UA_Kyiv = new DeliveryPoint() { Country = CountryUA, City = "Kyiv" };
            DeliveryPoint UA_Lviv = new DeliveryPoint() { Country = CountryUA, City = "Lviv" };
            DeliveryPoint PL_Warsaw = new DeliveryPoint() { Country = CountryPL, City = "Warsaw" };
            DeliveryPoint PL_Krakow = new DeliveryPoint() { Country = CountryPL, City = "Krakow" };
            DeliveryPoint TR_Istanbul = new DeliveryPoint() { Country = CountryTR, City = "Istanbul" };
            DeliveryPoint TR_Antalya = new DeliveryPoint() { Country = CountryTR, City = "Antalya" };
            context.DeliveryPoints.AddRangeAsync(new DeliveryPoint[] { UA_Kyiv, UA_Lviv, PL_Warsaw, PL_Krakow, TR_Istanbul, TR_Antalya });

            PointsRange[] PR = new PointsRange[] {
                new PointsRange(){Point1 = UA_Kyiv, Point2 = UA_Lviv, Range = 498},
                new PointsRange(){Point1 = UA_Kyiv, Point2 = PL_Warsaw, Range = 690},
                new PointsRange(){Point1 = UA_Lviv, Point2 = PL_Warsaw, Range = 334},
                new PointsRange(){Point1 = PL_Warsaw, Point2 = PL_Krakow, Range = 252},
                new PointsRange(){Point1 = UA_Kyiv, Point2 = PL_Krakow, Range = 754},
                new PointsRange(){Point1 = UA_Lviv, Point2 = PL_Krakow, Range = 294},
                new PointsRange(){Point1 = UA_Kyiv, Point2 = TR_Istanbul, Range = 1058},
                new PointsRange(){Point1 = UA_Kyiv, Point2 = TR_Antalya, Range = 1505},
                new PointsRange(){Point1 = UA_Lviv, Point2 = TR_Istanbul, Range = 1056},
                new PointsRange(){Point1 = UA_Lviv, Point2 = TR_Antalya, Range = 1538},
                new PointsRange(){Point1 = PL_Warsaw, Point2 = TR_Istanbul, Range = 1387},
                new PointsRange(){Point1 = PL_Warsaw, Point2 = TR_Antalya, Range = 1863},
                new PointsRange(){Point1 = PL_Krakow, Point2 = TR_Istanbul, Range = 1225},
                new PointsRange(){Point1 = PL_Krakow, Point2 = TR_Antalya, Range = 1709}
            };
            context.PointsRanges.AddRangeAsync(PR);

            var ServiceFly = new Service() { Name = "Fly to another City", Type = ServiceType.Passenger };
            var ServiceBag = new Service() { Name = "Baggage", Type = ServiceType.Cargo };
            var ServiceDinner = new Service() { Name = "Dinner", Type = ServiceType.Kitchen };
            var ServiceWater = new Service() { Name = "Water", Type = ServiceType.Kitchen };
            var ServiceWatch = new Service() { Name = "Casio watch", Type = ServiceType.DutyFree };
            var ServicePerfume = new Service() { Name = "Chanel perfume", Type = ServiceType.DutyFree };

            context.Services.AddRangeAsync(new Service[] { ServiceFly, ServiceBag, ServiceDinner, ServiceWater, ServiceWatch, ServicePerfume });

            var PriceFly1 = new Price() { Service = ServiceFly, RangeStart = 0, RangeEnd = 400, Amount = 600 };
            var PriceFly2 = new Price() { Service = ServiceFly, RangeStart = 401, RangeEnd = 700, Amount = 800 };
            var PriceFly3 = new Price() { Service = ServiceFly, RangeStart = 701, RangeEnd = 1100, Amount = 1000 };
            var PriceFly4 = new Price() { Service = ServiceFly, RangeStart = 1101, RangeEnd = 1500, Amount = 1300 };
            var PriceFly5 = new Price() { Service = ServiceFly, RangeStart = 1501, RangeEnd = 99999999, Amount = 2000 };
            var PriceBaggage = new Price() { Service = ServiceBag, Amount = 900 };
            var PriceDinner = new Price() { Service = ServiceDinner, Amount = 1500 };
            var PriceWater = new Price() { Service = ServiceWater, Amount = 50 };
            var PriceWatch = new Price() { Service = ServiceWatch, Amount = 10000 };
            var PricePerfume = new Price() { Service = ServicePerfume, Amount = 5000 };

            context.Prices.AddRangeAsync(new Price[] { PriceFly1, PriceFly2, PriceFly3, PriceFly4, PriceFly5, PriceBaggage, PriceDinner, PriceWater, PriceWatch, PricePerfume });

            var DiscountVIP_fly = new Discount() { Service = ServiceFly, Type = DiscountType.Percent, Amount = 5, UserRole = RoleVIP };
            var DiscountVIP_Dinner = new Discount() { Service = ServiceDinner, Type = DiscountType.Amount, Amount = 200, UserRole = RoleVIP };
            var DiscountVIP_Bag = new Discount() { Service = ServiceBag, Type = DiscountType.Amount, Amount = 300, UserRole = RoleVIP };
            var DiscountEmp_fly = new Discount() { Service = ServiceFly, Type = DiscountType.Percent, Amount = 20, UserRole = RoleAdmin };
            var DiscountEmp_Dinner = new Discount() { Service = ServiceDinner, Type = DiscountType.Percent, Amount = 100, UserRole = RoleAdmin };
            var DiscountEmp_Water = new Discount() { Service = ServiceWater, Type = DiscountType.Percent, Amount = 100, UserRole = RoleAdmin };
            var DiscountEmp_Bag = new Discount() { Service = ServiceBag, Type = DiscountType.Amount, Amount = 500, UserRole = RoleAdmin };

            context.Discounts.AddRangeAsync(new Discount[] { DiscountVIP_fly, DiscountVIP_Dinner, DiscountVIP_Bag, DiscountEmp_fly, DiscountEmp_Dinner, DiscountEmp_Water, DiscountEmp_Bag });
        }

        private static Airplane[] AddAirplans(ApplicationContext context, int Qty, AirplaneModel Model) {
            Airplane[] Airplans = new Airplane[Qty];
            for (int i = 0; i < Airplans.Length; i++) {
                Airplans[i] = new Airplane() { DateCreated = DateTime.Today, Model = Model, SerialNumber = Guid.NewGuid().ToString() };
            }
            context.Airplanes.AddRangeAsync(Airplans);
            return Airplans;
        }
    }
}
