using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Configuracion
{
    public class DetalleOrdenConfiguracion: IEntityTypeConfiguration<DetalleOrden>
    {
            public void Configure(EntityTypeBuilder<DetalleOrden> entity)
        {
            entity.HasKey(x => x.Id);

            /* entity.HasOne(x => x.Articulo)*/

            entity.Property(x => x.Cantidad).IsRequired();

            entity.Property(x => x.PrecioUnitario).HasColumnType("decimal(10, 2)").IsRequired();

            entity.Property(x => x.SubTotal).HasColumnType("decimal(10, 2)").IsRequired();

            entity.HasOne(x => x.Orden)
                .WithMany(y => y.DetalleOrden)
                .HasForeignKey(x => x.IdOrden);

            entity.HasOne(x => x.Articulo)
               .WithMany(y => y.DetalleOrden)
               .HasForeignKey(x => x.IdArticulo);

        }
   
    }
}
