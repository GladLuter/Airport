using LikeABird.DAL.Models.Earnings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.EF.Configurations;
class ConfigUserOperation : IEntityTypeConfiguration<UserOperation>
{
    public void Configure(EntityTypeBuilder<UserOperation> builder)
    {
        string KeyName = "UserId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.User).WithMany(s => s.UserOperations).HasForeignKey(KeyName).IsRequired(true);
        KeyName = "TransferId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.Transfer).WithMany(s => s.UserOperations).HasForeignKey(KeyName).IsRequired(true);
    }
}

