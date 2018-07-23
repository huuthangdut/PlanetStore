using AutoMapper;
using Planet.Data.Core.Domain;
using Planet.Infrastructure.Extensions;
using Planet.WebApi.Dtos.Auth;
using Planet.WebApi.Dtos.Notification;
using System;
using System.Globalization;
using Planet.WebApi.Dtos.ECommerce;

namespace Planet.WebApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppRole, AppRoleDto>().MaxDepth(2);
            CreateMap<AppRoleDto, AppRole>().IgnoreMember(p => p.Id).MaxDepth(2);


            CreateMap<AppUser, AppUserDto>().MaxDepth(2);

            CreateMap<AppUserDto, AppUser>().IgnoreMember(u => u.Id)
                .IgnoreMember(u => u.Roles)
                .ForMember(u => u.Birthdate,
                    opt => opt.MapFrom(x => DateTime.ParseExact(x.BirthDate, "dd/MM/yyyy", new CultureInfo("vi-VN"))))
                .MaxDepth(2);


            CreateMap<Permission, PermissionDto>().MaxDepth(2);
            CreateMap<PermissionDto, Permission>().MaxDepth(2);

            CreateMap<ProductCategory, ProductCategoryDto>().MaxDepth(2);
            CreateMap<ProductCategoryDto, ProductCategory>().IgnoreMember(p => p.Id).MaxDepth(2);

            CreateMap<Product, ProductDto>().MaxDepth(2);
            CreateMap<ProductDto, Product>().IgnoreMember(p => p.Id).MaxDepth(2);

            CreateMap<ProductImage, ProductImageDto>().MaxDepth(2);
            CreateMap<ProductImageDto, ProductImage>().IgnoreMember(p => p.Id).MaxDepth(2);

            CreateMap<Function, FunctionDto>().MaxDepth(2);

            CreateMap<Announcement, AnnouncementDto>().MaxDepth(2);
            CreateMap<AnnouncementDto, Announcement>().IgnoreMember(m => m.Id).MaxDepth(2);

            CreateMap<AnnouncementUser, AnnouncementUserDto>().MaxDepth(2);
            CreateMap<AnnouncementUserDto, AnnouncementUser>().MaxDepth(2);
        }
    }
}