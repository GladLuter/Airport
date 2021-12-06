using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeABird.DAL.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeABird.DAL.EF.Configurations;
class ConfigEmployeePermition : IEntityTypeConfiguration<EmployeePermition>
{
    public void Configure(EntityTypeBuilder<EmployeePermition> builder)
    {
        string KeyName = "RoleId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.Role).WithMany(s => s.EmployeePermitions).HasForeignKey(KeyName).IsRequired(true);
    }
}

