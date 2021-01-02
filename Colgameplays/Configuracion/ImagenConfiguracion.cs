using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Configuracion
{
    public class ImagenConfiguracion : IEntityTypeConfiguration<Imagen>
    {
        public void Configure(EntityTypeBuilder<Imagen> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Foto).IsRequired();

            entity.HasOne(x => x.Articulo)
                .WithMany(y => y.Imagen)
                .HasForeignKey(x => x.IdArticulo);
        }
    }
}
