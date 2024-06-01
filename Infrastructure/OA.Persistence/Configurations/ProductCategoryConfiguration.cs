﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        void IEntityTypeConfiguration<ProductCategory>.Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });
            builder.HasOne(p => p.Product).WithMany(pc => pc.ProductCategories).HasForeignKey(p=>p.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Category).WithMany(pc => pc.ProductCategories).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
