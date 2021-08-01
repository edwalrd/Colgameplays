using Colgameplays.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.ModelSetting
{
    public class OrderDetailsSetting : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> entity)
        {
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Article)
                .WithMany(y => y.OrderDetailS)
                .HasForeignKey(z => z.IdArticle);

             entity.HasOne(x => x.Order)
            .WithMany(y => y.OrderDetails)
            .HasForeignKey(z => z.IdOrder);

            entity.Property(x => x.quantity).IsRequired();

            entity.Property(x => x.Unitprice)
                .HasColumnType("decimal(10 , 2)")
                .IsRequired();

            entity.Property(x => x.SubTotal)
            .HasColumnType("decimal(10 , 2)")
            .IsRequired();

        }
    }
}
