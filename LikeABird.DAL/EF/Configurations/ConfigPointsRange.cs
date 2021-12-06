using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeABird.DAL.Models.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeABird.DAL.EF.Configurations;
class ConfigPointsRange : IEntityTypeConfiguration<PointsRange>
{
    public void Configure(EntityTypeBuilder<PointsRange> builder)
    {

    }
}

