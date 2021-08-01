using Colgameplays.Entities;
using Colgameplays.Model.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class UserSetting : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)

        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
            .HasMaxLength(300)
            .IsRequired();

            entity.Property(x => x.LastName)
            .HasMaxLength(300)
            .IsRequired();

            entity.Property(x => x.Email)
            .HasMaxLength(300)
            .IsUnicode()
            .IsRequired();

            entity.Property(x => x.Password)
          .HasMaxLength(300)
          .IsRequired();

            entity.Property(x => x.Age)
                .IsRequired();

            entity.Property(x => x.Role)
                .HasMaxLength(100)
                .HasConversion(x => x.ToString(), x => (Roles)Enum.Parse(typeof(Roles), x))
              .IsRequired();

            entity.Property(x => x.CreationDate)
                .HasDefaultValue(DateTime.Now);

            entity.Property(x => x.ModifiedDate)
              .HasDefaultValue(DateTime.Now)
              .IsRequired();

        }
    }
}

