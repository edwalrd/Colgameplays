using Colgameplays.Entities;
using Colgameplays.Model.Entities;
using Colgameplays.ModelSetting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays
{
    public partial class ColgameplaysContext : DbContext
    {

        public ColgameplaysContext(DbContextOptions<ColgameplaysContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addres { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Consoles> Consoles { get; set; }
        public DbSet<Cart_Item> Cart_Items { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingSeccion> ShoppingSeccions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AdressSetting());
            modelBuilder.ApplyConfiguration(new ArticleSetting());
            modelBuilder.ApplyConfiguration(new BrandSetting());
            modelBuilder.ApplyConfiguration(new Cart_ItemSetting());
            modelBuilder.ApplyConfiguration(new CategorySetting());
            modelBuilder.ApplyConfiguration(new ConsolesSetting());
            modelBuilder.ApplyConfiguration(new ImagesSetting());
            modelBuilder.ApplyConfiguration(new OrdersSetting());
            modelBuilder.ApplyConfiguration(new OrderDetailsSetting());
            modelBuilder.ApplyConfiguration(new ShoppingSeccionSetting());
            modelBuilder.ApplyConfiguration(new UserSetting());



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
