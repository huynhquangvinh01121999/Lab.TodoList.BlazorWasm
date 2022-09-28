using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TodoList.BlazorWasm.Domain.Entities;

namespace TodoList.BlazorWasm.Persistence.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUsers, AppRoles, Guid>
    {
        private string defaultSchema = "Lab"; 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");

            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");

            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

            builder.HasDefaultSchema(defaultSchema);

            builder.Entity<Todos>().HasKey(x => x.Id);
            builder.Entity<Types>().HasKey(x => x.Id);

            builder.Entity<Todos>().HasOne<Types>(x => x.Types).WithMany(x => x.Todos).HasForeignKey(x => x.TypeId);
            builder.Entity<Todos>().HasOne<AppUsers>(x => x.Users).WithMany(x => x.Todos).HasForeignKey(x => x.UserId);

            base.OnModelCreating(builder);
        }
        public DbSet<Todos> TodoLists { get; set; }
        public DbSet<Types> Types { get; set; }
    }
}
