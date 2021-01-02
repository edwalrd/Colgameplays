using AutoMapper;
using Colgameplays.model;
using Colgameplays.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Colgameplays.Model;
using Colgameplays.Dtos.Categoria;
using Colgameplays.Dtos.Domicilio;
using Colgameplays.Dtos.Carrito;
using Colgameplays.Dtos.Orden;
using Colgameplays.Dtos.Articulo;
using Colgameplays.Dtos.Usuario;
using Colgameplays.Dtos.Imagen;

namespace Colgameplays.Profiles
{
    public class ColgameplaysProfiles: Profile
    {
       public ColgameplaysProfiles()
        {


            /*Articulo*/
            this.CreateMap<Articulo, GetArticulosDto>().ReverseMap();
            this.CreateMap<Articulo, ArticuloDto>().ReverseMap();

            /*Plataforma*/
            this.CreateMap<Plataforma, PlataformaDtos>().ReverseMap();

            /*Consola*/

            this.CreateMap<Consola, ConsolasDtos>().ReverseMap();
            this.CreateMap<Consola, AddConsolaDtos>().ReverseMap();
            this.CreateMap<Consola, ConsolasPutDto>().ReverseMap();

            /*Categoria*/

            this.CreateMap<Categoria, CategoriaDto>().ReverseMap();

            /*Carrito*/
            this.CreateMap<Carrito, CarritoDto>().ReverseMap();
            this.CreateMap<Carrito, GetCarriotDto>().ReverseMap();

            /*Domicilio*/
            this.CreateMap<Domicilio, DomicilioDto>().ReverseMap();

            /*Orden*/

            this.CreateMap<Orden, OrdenDto>().ReverseMap();
            this.CreateMap<Orden, GetOrdenDtos>().ReverseMap();

            this.CreateMap<DetalleOrden, DetalleOrdenDto>().ReverseMap();
            this.CreateMap<DetalleOrden, GetDetalleOrdenDto>().ReverseMap();

            /*Usuario*/
            this.CreateMap<Usuario, GetUsuarioDto>().ReverseMap();

            this.CreateMap<Usuario, UsuarioDtos>().ReverseMap();

            /*Imagen*/
            this.CreateMap<Imagen, ImagenDto>().ReverseMap();
            this.CreateMap<Imagen, GetAddImagenDto>().ReverseMap();
            

        }
    }
}


