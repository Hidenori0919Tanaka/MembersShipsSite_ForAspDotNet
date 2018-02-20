using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using MemberShips.Entites;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using static System.Collections.Specialized.BitVector32;

namespace MemberShips.Models
{
    // ApplicationUser クラスにさらにプロパティを追加すると、ユーザーのプロファイル データを追加できます。詳細については、https://go.microsoft.com/fwlink/?LinkID=317594 を参照してください。
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public DateTime Registered { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // authenticationType が CookieAuthenticationOptions.AuthenticationType で定義されているものと一致している必要があります
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // ここにカスタム ユーザー クレームを追加します
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Entites.Section> Sections { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductLinkText> ProductLinkTexts { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<SubscriptionProduct> SubscriptionProducts { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
    }
}