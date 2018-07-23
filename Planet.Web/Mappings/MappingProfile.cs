using AutoMapper;
using Planet.Data.Core.Domain;
using Planet.Infrastructure.Extensions;
using Planet.Web.Models;
using Planet.Web.Models.Products;
using Planet.Web.Models.Shopping;

namespace Planet.Web.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().MaxDepth(2);
            CreateMap<ProductViewModel, Product>().IgnoreMember(p => p.Id).MaxDepth(2);

            CreateMap<Product, ProductSearchViewModel>().MaxDepth(2);

            CreateMap<ProductCategory, ProductCategoryViewModel>().MaxDepth(2);
            CreateMap<ProductCategoryViewModel, ProductCategory>().IgnoreMember(c => c.Id).MaxDepth(2);

            CreateMap<ProductTag, ProductTagViewModel>().MaxDepth(2);
            CreateMap<ProductTagViewModel, ProductTag>().MaxDepth(2);

            //CreateMap<Post, PostViewModel>().IgnoreMember(p => p.).MaxDepth(2);
            //CreateMap<PostViewModel, Post>().MaxDepth(2);

            //CreateMap<PostCategory, PostCategoryViewModel>().IgnoreMember(c => c.Id).MaxDepth(2);
            //CreateMap<PostCategoryViewModel, PostCategory>().MaxDepth(2);

            //CreateMap<PostTag, PostTagViewModel>().MaxDepth(2);
            //CreateMap<PostTagViewModel, PostTag>().MaxDepth(2);

            CreateMap<Slide, SlideViewModel>().MaxDepth(2);
            CreateMap<SlideViewModel, Slide>().IgnoreMember(s => s.Id).MaxDepth(2);

            CreateMap<Page, PageViewModel>().MaxDepth(2);
            CreateMap<PageViewModel, Page>().IgnoreMember(p => p.Id).MaxDepth(2);

            CreateMap<ProductImage, ProductImageViewModel>().MaxDepth(2);
            CreateMap<ProductImageViewModel, ProductImage>().IgnoreMember(i => i.Id).MaxDepth(2);

            CreateMap<Order, OrderViewModel>().MaxDepth(2);
            CreateMap<OrderViewModel, Order>().IgnoreMember(i => i.Id).MaxDepth(2);

            CreateMap<OrderDetail, OrderDetailViewModel>().MaxDepth(2);
            CreateMap<OrderDetailViewModel, OrderDetail>().MaxDepth(2);

            CreateMap<Contact, ContactViewModel>().MaxDepth(2);
            CreateMap<ContactViewModel, Contact>().MaxDepth(2);

            CreateMap<Feedback, FeedbackViewModel>().MaxDepth(2);
            CreateMap<FeedbackViewModel, Feedback>().MaxDepth(2);

            CreateMap<Menu, MenuViewModel>().MaxDepth(2);
            CreateMap<MenuViewModel, Menu>().MaxDepth(2);

            CreateMap<Cart, CartItemViewModel>().MaxDepth(2);
            CreateMap<CartItemViewModel, Cart>().MaxDepth(2);

            CreateMap<PaymentMethod, PaymentMethodViewModel>().MaxDepth(2);

        }
    }
}