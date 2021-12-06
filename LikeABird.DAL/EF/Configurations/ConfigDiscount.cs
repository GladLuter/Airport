using LikeABird.DAL.Models.Earnings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.EF.Configurations;
class ConfigDiscount : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        string KeyName = "ServiceId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.Service).WithMany(s => s.Discounts).HasForeignKey(KeyName).IsRequired(true);
        KeyName = "UserRoleId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.UserRole).WithMany(s => s.Discounts).HasForeignKey(KeyName).IsRequired(true);
    }
}

