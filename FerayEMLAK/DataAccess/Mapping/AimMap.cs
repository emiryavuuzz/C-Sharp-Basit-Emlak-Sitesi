using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapping
{
    public class AimMap : IEntityTypeConfiguration<Aim>
    {
        public void Configure(EntityTypeBuilder<Aim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(70);

            builder.HasMany(x => x.Product).WithOne(x => x.Aim).HasForeignKey(x => x.AimId);
     

            builder.ToTable("Aim");
        }
    }
}

