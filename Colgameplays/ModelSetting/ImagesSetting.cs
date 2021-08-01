using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class ImagesSetting : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .IsRequired();

             entity.Property(x => x.CreationDate)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();

            entity.Property(x => x.ModifiedDate)
              .HasDefaultValue(DateTime.Now)
              .IsRequired();

            entity.HasOne(x => x.Article)
                .WithMany(y => y.Images)
                .HasForeignKey(z => z.IdArticle);
        }
    }
}
