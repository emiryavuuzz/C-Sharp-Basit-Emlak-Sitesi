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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Date).HasColumnType("datetime");
            builder.Property(x => x.City).HasMaxLength(60);
            builder.Property(x => x.District).HasMaxLength(80);
            builder.Property(x => x.FullAdress).HasMaxLength(400);
            builder.Property(x => x.Price).HasColumnType("money");
            builder.Property(x => x.Room).HasMaxLength(20);
            builder.Property(x => x.Floor).HasMaxLength(20);
            builder.Property(x => x.UsingStatus).HasMaxLength(40);
            builder.Property(x => x.DeedStatus).HasMaxLength(50);
            builder.Property(x => x.Olcu).HasMaxLength(40);

            builder.HasOne(x => x.Aim).WithMany(x => x.Product).HasForeignKey(x => x.AimId);
            builder.HasOne(x => x.Categories).WithMany(x => x.Product).HasForeignKey(x => x.CategoriesId);
       
           

            builder.HasMany(x => x.Properties).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.ProductImages).WithOne(x => x.Product).HasForeignKey(x => x.ProductId);
            


            builder.ToTable("Product");

        }
    }
}
