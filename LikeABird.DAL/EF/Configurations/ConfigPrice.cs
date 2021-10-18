using LikeABird.DAL.Models.Earnings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LikeABird.DAL.EF.Configurations {
    class ConfigPrice : IEntityTypeConfiguration<Price> {
        public void Configure(EntityTypeBuilder<Price> builder) {
            string KeyName = "ServiceId";
            builder.Property<int>(KeyName);
            builder.HasOne(s => s.Service).WithMany(s => s.Prices).HasForeignKey(KeyName).IsRequired(true);
        }
    }
}
