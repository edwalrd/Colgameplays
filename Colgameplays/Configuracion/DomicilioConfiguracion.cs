using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Configuracion
{
    public class DomicilioConfiguracion: IEntityTypeConfiguration<Domicilio>
    {
        public void Configure(EntityTypeBuilder<Domicilio> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Ciudad).IsRequired();

            entity.Property(x => x.Direccion).IsRequired();

            entity.Property(x => x.Celular).IsRequired();

            entity.HasOne(x => x.Usuario)
              .WithOne(y => y.Domicilio)
              .HasForeignKey<Domicilio>(x => x.IdUsuario);
        }
    }
}
