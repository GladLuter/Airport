using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeABird.DAL.Models.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeABird.DAL.EF.Configurations;
class ConfigAirplane : IEntityTypeConfiguration<Airplane>
{
    public void Configure(EntityTypeBuilder<Airplane> builder)
    {
        string KeyName = "ModelId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.Model).WithMany(s => s.Airplanes).HasForeignKey(KeyName).IsRequired(true);
    }
}

