using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeABird.DAL.Models.Logistic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace LikeABird.DAL.EF.Configurations;
class ConfigTicket : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        string KeyName = "UserId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.User).WithMany(s => s.Tickets).HasForeignKey(KeyName).IsRequired(true);
        KeyName = "TransferId";
        builder.Property<int>(KeyName);
        builder.HasOne(s => s.Transfer).WithMany(s => s.Tickets).HasForeignKey(KeyName).IsRequired(true);
        //builder.HasOne(s => s.Transport).WithMany(s => s.).HasForeignKey(x => x.Transport).IsRequired(true);
    }
}

