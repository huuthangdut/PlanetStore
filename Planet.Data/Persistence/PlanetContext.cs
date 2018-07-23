using Microsoft.AspNet.Identity.EntityFramework;
using Planet.Data.Core.Domain;
using System.Data.Entity;

namespace Planet.Data.Persistence
{
    public class PlanetContext : IdentityDbContext<AppUser>
    {
        public PlanetContext() : base("PlanetConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Footer> Footers { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementUser> AnnouncementUsers { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }


        public DbSet<Error> Errors { get; set; }
        public DbSet<Page> Pages { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }

        public DbSet<Function> Functions { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<IdentityUserRole> AppUserRoles { get; set; }


        public static PlanetContext Create()
        {
            return new PlanetContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("AppUsers");
            builder.Entity<IdentityRole>().ToTable("AppRoles");
            builder.Entity<IdentityUserRole>().ToTable("AppUserRoles");
            builder.Entity<IdentityUserLogin>().ToTable("AppUserLogins");
            builder.Entity<IdentityUserClaim>().ToTable("AppUserClaims");

            builder.Entity<Order>()
                .HasRequired(o => o.Status)
                .WithMany()
                .WillCascadeOnDelete(false);
            builder.Entity<Order>()
                .HasRequired(o => o.PaymentMethod)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}
