using Colgameplays.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class OrdersSetting: IEntityTypeConfiguration <Order>
    {
        public void Configure (EntityTypeBuilder <Order> entity)
        {
            entity.HasKey(x => x.id);

            entity.Property(x => x.discount).HasDefaultValue(0);

            entity.Property(x => x.SubTotal)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            entity.Property(x => x.Total)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            entity.Property(x => x.Fecha)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            entity.HasOne(x => x.User)
                .WithMany(y => y.Orders)
                .HasForeignKey(z => z.IdUser);
        }
    }
}
