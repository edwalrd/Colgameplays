using Colgameplays.Enumerations;
using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Configuracion
{
    public class ArticuloConfiguracion : IEntityTypeConfiguration<Articulo>
    {
        public void Configure(EntityTypeBuilder <Articulo> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();

            entity.Property(x => x.Descripcion).HasMaxLength(500);

            entity.Property(x => x.Precio).HasColumnType("decimal(10 , 2)").IsRequired();

            entity.Property(x => x.Estado)
                .IsRequired()
                .HasConversion(
                
                x=> x.ToString(),
                x => (Estado)Enum.Parse(typeof(Estado), x)
                );

            entity.Property(x => x.Fecha)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            entity.HasOne(x => x.Consola)
                .WithMany(y => y.Articulo)
                .HasForeignKey(x => x.Idconsola);

            entity.HasOne(x => x.Categoria)
                .WithMany(y => y.Articulo)
                .HasForeignKey(x => x.IdCategoria);

        }
    }
}
