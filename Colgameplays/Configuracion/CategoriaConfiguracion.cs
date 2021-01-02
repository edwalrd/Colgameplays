using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Configuracion
{
    public class CategoriaConfiguracion: IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> entity)
        {
            entity.HasKey(x=> x.Id);

            entity.Property(x => x.Nombre).IsRequired();
        }
    }
}
