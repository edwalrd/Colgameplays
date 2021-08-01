using Colgameplays.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class AdressSetting : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Ciudad)
            .HasMaxLength(200)
            .IsRequired();

            entity.Property(x => x.Direccion)
            .HasMaxLength(200)
            .IsRequired();

            entity.Property(x => x.Telefono)
           .HasMaxLength(200)
           .IsRequired();

            entity.HasOne(x => x.User)
                .WithMany(y => y.Address)
                .HasForeignKey(z => z.IdUser);

        }
    }
}
