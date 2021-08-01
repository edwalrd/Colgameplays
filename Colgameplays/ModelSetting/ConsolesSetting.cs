using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class ConsolesSetting : IEntityTypeConfiguration <Consoles>
    {
        public void Configure (EntityTypeBuilder<Consoles> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.IdBrand)
                .IsRequired();

            entity.Property(x => x.CreationDate)
           .HasDefaultValue(DateTime.Now)
           .IsRequired();

            entity.Property(x => x.ModifiedDate)
              .HasDefaultValue(DateTime.Now)
              .IsRequired();

            entity.HasOne(x => x.Brand)
                .WithMany(y => y.Consoles)
                .HasForeignKey(z => z.IdBrand);

        }
    }
}
