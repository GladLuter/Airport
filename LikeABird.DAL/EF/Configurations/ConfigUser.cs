using LikeABird.DAL.Models.Earnings;
using LikeABird.DAL.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        builder.Property<int>(KeyName).UsePropertyAccessMode(PropertyAccessMode.Property);
        builder.HasOne(s => s.UserRole).WithMany(s => s.Users).HasForeignKey(KeyName).IsRequired(true);
    }
}

