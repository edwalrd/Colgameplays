using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class ShoppingSeccionSetting: IEntityTypeConfiguration<ShoppingSeccion>
    {
        public void Configure(EntityTypeBuilder <ShoppingSeccion> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Total)
                .HasColumnType("decimal(10,2)")
                .HasDefaultValue(0)
                .IsRequired();

            entity.Property(x => x.CreationDate)
              .HasDefaultValue(DateTime.Now)
              .IsRequired();
            
            entity.Property(x => x.ModifiedDate)
              .HasDefaultValue(DateTime.Now)
              .IsRequired();

            entity.HasOne(x => x.User)
                .WithOne(y => y.ShoppingSeccion)
                .HasForeignKey<ShoppingSeccion>(z => z.IdUser);
        }
    }
}
