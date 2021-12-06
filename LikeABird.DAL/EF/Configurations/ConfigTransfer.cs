using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeABird.DAL.Models.Logistic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeABird.DAL.EF.Configurations;
class ConfigTransfer : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        string KeyName = "ServiceId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.Service).WithMany(s => s.Transfers).HasForeignKey(KeyName).IsRequired(true);
        //builder.HasOne(s => s.PointsRange).WithMany(s => s.).HasForeignKey(x => x.Service).IsRequired(true);
    }
}

