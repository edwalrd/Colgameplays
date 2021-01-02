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
    public class UsuarioConfiguracion: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(100);


            entity.Property(x => x.Apellido)
                .IsRequired()
                .HasMaxLength(100);


            entity.Property(x => x.User)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();


            entity.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.Role)
              .IsRequired()
              .HasMaxLength(100)
              .HasConversion(
                x => x.ToString(),
                x => (Roles)Enum.Parse(typeof(Roles) ,x ))
              ;

            entity.Property(x => x.FechaCreacion)
               .IsRequired()
              .HasDefaultValue(DateTime.Now);

        }

    }
}
