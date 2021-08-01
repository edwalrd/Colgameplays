using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class CategorySetting : IEntityTypeConfiguration<Category>
    {
        public void Configure (EntityTypeBuilder <Category> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.Description)
              .HasMaxLength(1000)
              .IsRequired();
        }
    }
}
