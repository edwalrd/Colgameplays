using Colgameplays.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Configuracion
{
    public class ConsolaConfiguracion : IEntityTypeConfiguration<Consola>
    {

        public void Configure(EntityTypeBuilder <Consola> entity)
        {

            entity.HasKey(x => x.Id);


            entity.Property(x => x.Nombre).HasMaxLength(100).IsRequired();

            entity.Property(x => x.Precio).HasColumnType("decimal(10 , 2)").IsRequired();

            entity.Property(x => x.Idplataforma).IsRequired();
        

            entity.HasOne(x => x.Plataforma)
            .WithMany(y => y.Consolas)
            .HasForeignKey(x => x.Idplataforma);

        }

    }
}

