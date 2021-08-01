using Colgameplays.Entities;
using Colgameplays.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class Cart_ItemSetting : IEntityTypeConfiguration<Cart_Item>
    {
        public void Configure(EntityTypeBuilder<Cart_Item> entity)
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Quantity)
                .IsRequired();

            entity.Property(x => x.CreationDate)
            .HasDefaultValue(DateTime.Now)
            .IsRequired();

            entity.Property(x => x.ModifiedDate)
              .HasDefaultValue(DateTime.Now)
              .IsRequired();

            entity.HasOne(X => X.Article)
            .WithMany(y => y.Cart_Items)
            .HasForeignKey(z => z.IdArticle);

            entity.HasOne(X => X.shoppingSeccion)
               .WithMany(y => y.Cart_Item)
            .HasForeignKey(z => z.IdShoppingSeccion);

        }
    }
}
