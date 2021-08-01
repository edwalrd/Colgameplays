using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class ArticleSetting: IEntityTypeConfiguration<Article>
    {
        public void Configure (EntityTypeBuilder <Article> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(1000).IsRequired();

            entity.Property(x => x.Price)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            entity.Property(x => x.Description)
             .IsRequired();

            entity.Property(x => x.Condition)
                .HasConversion(x => x.ToString(), x => (Condition)Enum.Parse(typeof(Condition), x))
                .IsRequired();

            entity.Property(x => x.CreationDate).HasDefaultValue(DateTime.Now);

            entity.Property(x => x.ModifiedDate).HasDefaultValue(DateTime.Now);

            ///////Relaciones

            entity.HasOne(x => x.Category)
                .WithMany(y => y.Articles)
                .HasForeignKey(z => z.IdCategory);

            entity.HasOne(x => x.Consoles)
            .WithMany(y => y.Articles)
            .HasForeignKey(z => z.IdConsole);


        }

    }
}
