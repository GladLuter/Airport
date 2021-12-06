using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeABird.DAL.Models.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeABird.DAL.EF.Configurations;
class ConfigDeliveryPoint : IEntityTypeConfiguration<DeliveryPoint>
{
    public void Configure(EntityTypeBuilder<DeliveryPoint> builder)
    {
        string KeyName = "CountryId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.Country).WithMany(s => s.DeliveryPoints).HasForeignKey(KeyName).IsRequired(true);
    }
}

