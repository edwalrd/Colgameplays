using Colgameplays.Configuracion;
using Colgameplays.model;
using Colgameplays.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays.Context
{
    public partial class ColgamesplaysContenxt: DbContext
    {
        public ColgamesplaysContenxt(DbContextOptions<ColgamesplaysContenxt> options)
            :base(options)
        {
        }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<DetalleOrden> DetalleOrdens { get; set; }
        public DbSet<Orden> Ordens { get; set; }
        public DbSet<Consola> Consolas { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imagen> Imagens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticuloConfiguracion());

            modelBuilder.ApplyConfiguration(new CategoriaConfiguracion());

            modelBuilder.ApplyConfiguration(new CarritoConfiguracion());

            modelBuilder.ApplyConfiguration(new DomicilioConfiguracion());

            modelBuilder.ApplyConfiguration(new DetalleOrdenConfiguracion());

            modelBuilder.ApplyConfiguration(new OrdenConfiguracion());

            modelBuilder.ApplyConfiguration(new ConsolaConfiguracion());

            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());

            modelBuilder.ApplyConfiguration(new ImagenConfiguracion());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    
    }
}
