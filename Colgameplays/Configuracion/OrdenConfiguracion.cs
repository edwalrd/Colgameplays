using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Configuracion
{
    public class OrdenConfiguracion : IEntityTypeConfiguration<Orden>
    {
        public void Configure(EntityTypeBuilder<Orden> entity)
        {
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Usuario)
                .WithMany(y => y.Orden)
                .HasForeignKey(x => x.IdUsuario);

            entity.Property(x => x.Descuento).HasColumnType("decimal(10 , 2)").HasDefaultValue(0).IsRequired();

            entity.Property(x => x.Total).HasColumnType("decimal(10 , 2)").HasDefaultValue(0).IsRequired();

            entity.Property(x => x.Fecha)
            .IsRequired()
           .HasDefaultValue(DateTime.Now);

        }
    }
}
