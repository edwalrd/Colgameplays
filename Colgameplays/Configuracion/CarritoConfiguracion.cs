using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Configuracion
{
    public class CarritoConfiguracion : IEntityTypeConfiguration<Carrito>
    {
        public void Configure(EntityTypeBuilder<Carrito> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Cantidad).IsRequired();

            entity.Property(x => x.Fecha)
             .IsRequired()
            .HasDefaultValue(DateTime.Now);

            entity.HasOne(x => x.Usuario)
            .WithMany(y => y.Carrito)
            .HasForeignKey(x => x.IdUsuario);

            entity.HasOne(x => x.Articulo)
            .WithOne(y => y.Carrito)
            .HasForeignKey<Carrito>(x => x.IdArticulo);
        }
    }
}
