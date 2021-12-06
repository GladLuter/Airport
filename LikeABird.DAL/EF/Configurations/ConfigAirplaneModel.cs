using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LikeABird.DAL.Models.Resource;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LikeABird.DAL.EF.Configurations;
class ConfigAirplaneModel : IEntityTypeConfiguration<AirplaneModel>
{
    public void Configure(EntityTypeBuilder<AirplaneModel> builder)
    {

    }
}

