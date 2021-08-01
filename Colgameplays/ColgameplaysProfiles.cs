using AutoMapper;
using Colgameplays.Dtos.AddressDtos;
using Colgameplays.Dtos.ArticleDtos;
using Colgameplays.Dtos.BrandDtos;
using Colgameplays.Dtos.Cart_Item;
using Colgameplays.Dtos.Category;
using Colgameplays.Dtos.Consoles;
using Colgameplays.Dtos.ImagenDtos;
using Colgameplays.Dtos.OrderDtos;
using Colgameplays.Dtos.ShoppingSeccionDtos;
using Colgameplays.Dtos.User;
using Colgameplays.Dtos.UserDtos;
using Colgameplays.Entities;
using Colgameplays.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Colgameplays
{
    public class ColgameplaysProfiles : Profile
    {
        public ColgameplaysProfiles()
        {
            //Article -Session
            this.CreateMap<Article, CreateArticleDtos>()
                           .ReverseMap().ForMember(x => x.Consoles, y => y.Ignore())
                           .ForMember(x => x.Category, y => y.Ignore())
                           .ForMember(x => x.Cart_Items, y => y.Ignore())
                           .ForMember(x => x.OrderDetailS, y => y.Ignore())
                           .ForMember(x => x.Images, y => y.Ignore());

            this.CreateMap<Article, AllArticleDtos>()
                          .ReverseMap().ForMember(x => x.Images, y => y.Ignore())
                          .ForMember(x => x.Cart_Items, y => y.Ignore())
                          .ForMember(x => x.OrderDetailS, y => y.Ignore());

            this.CreateMap<Article, ArticleCart_Item>()
                          .ReverseMap().ForMember(x => x.Consoles, y => y.Ignore())
                           .ForMember(x => x.Category, y => y.Ignore())
                           .ForMember(x => x.OrderDetailS, y => y.Ignore())
                           .ForMember(x => x.Images, y => y.Ignore());

            //address -Session
            this.CreateMap<Address, AddressDto>()
                          .ReverseMap().ForMember(x => x.User, y => y.Ignore());

            //Brand -Session
            this.CreateMap<Brand, BrandDtos>()
              .ReverseMap().ForMember(x => x.Consoles, y => y.Ignore());

            //Console -Session
            this.CreateMap<Consoles, ConsoleDtos>()
                .ReverseMap().ForMember(x => x.Brand, y => y.Ignore())
                .ForMember(x => x.Articles, y => y.Ignore());

            //Image -Session
            this.CreateMap<Image, imageDtos>()
                .ReverseMap().ForMember(x => x.Article, y => y.Ignore());

            this.CreateMap<Image, GetImagenDto>()
            .ReverseMap().ForMember(x => x.Article, y => y.Ignore());

            //Cart_item -Session
            this.CreateMap<Cart_Item, Cart_ItemDtos>()
                .ReverseMap().ForMember(x => x.shoppingSeccion, y => y.Ignore());
                
            this.CreateMap<Cart_Item, AddCart_ItemDtos>()
               .ReverseMap().ForMember(x => x.Article, y => y.Ignore())
               .ForMember(x => x.shoppingSeccion, y => y.Ignore())
               ;

            //Category -Session
            this.CreateMap<Category, CategoryDtos>()
              .ReverseMap().ForMember(x => x.Articles, y => y.Ignore());



            //Order -Session

            this.CreateMap<Order, OrderDtos>()
             .ReverseMap();

            this.CreateMap<Order, AddOrderDtos>()
             .ReverseMap();

            this.CreateMap<Order, UpdateOrderDtos>()
            .ReverseMap().ForMember(x => x.OrderDetails, y => y.Ignore());


            this.CreateMap<Order, OrderDetailDtos>()
          .ReverseMap().ForMember(x => x.OrderDetails, y => y.Ignore());

            this.CreateMap<OrderDetail, UpdateOrderDetailDtos>()
            .ReverseMap().ForMember(x => x.Article, y => y.Ignore());

            this.CreateMap<OrderDetail, OrderDetailDtos>()
           .ReverseMap().ForMember(x => x.Article, y => y.Ignore());


            //User -Session
            this.CreateMap<User, CreateUserDtos>()
                .ReverseMap().ForMember(x => x.Orders, y => y.Ignore());

            this.CreateMap<User, RegisterUserDto>()
                .ReverseMap().ForMember(x => x.Orders, y => y.Ignore())
                .ForMember(x => x.Address, y => y.Ignore());

            this.CreateMap<User, UserAdressDtos>()
                .ReverseMap().ForMember(x => x.ShoppingSeccion, y => y.Ignore())
                .ForMember(x => x.Orders, y => y.Ignore());

            this.CreateMap<User, UserDto>()
                .ReverseMap().ForMember(x => x.ShoppingSeccion, y => y.Ignore())
                .ForMember(x => x.Address, y => y.Ignore());

            this.CreateMap<User, UserAdressDtos>()
             .ReverseMap();

            this.CreateMap<User, UserOnlyAddress>()
             .ReverseMap();



            //Shopping -Session
            this.CreateMap<ShoppingSeccion, ShoppingSeccionDto>()
                .ReverseMap().ForMember(x => x.Cart_Item, y => y.Ignore());



        }
    }

}
