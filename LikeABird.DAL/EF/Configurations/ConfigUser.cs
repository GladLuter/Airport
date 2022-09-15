using LikeABird.DAL.Models.Earnings;
using LikeABird.DAL.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.EF.Configurations;
class ConfigUser : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        string KeyName = "UserRoleId";
        var prop = builder.Property<int>(KeyName);
        var con = builder.HasOne(u => u.UserRole).WithMany(r => r.Users).HasForeignKey(KeyName).IsRequired(true);
        
        //builder.ToSqlQuery<User>(@"
        //SELECT 
        //    [Id]
        //    ,[Name]
        //    ,[LastName]
        //    ,'phone' + [Phone] as Phone 
        //    ,[MainEmail]
        //    ,[UserRoleId] --as UserRole
        //    ,[Password]
        //FROM [dbo].[Users] as Users with(nolock) 
        //");

    }
}

