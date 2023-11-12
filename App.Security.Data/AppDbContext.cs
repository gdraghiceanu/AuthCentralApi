using App.Security.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using App.Security.Helper;

namespace App.Security.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserClaim>().HasData(
                new AppUserClaim() { Id = 1, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.ADD_USER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                new AppUserClaim() { Id = 2, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.EDIT_USER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                new AppUserClaim() { Id = 3, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.DELETE_USER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                new AppUserClaim() { Id = 4, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.GET_USER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },

                new AppUserClaim() { Id = 5, ClaimType = Constants.ROLE_USER, ClaimValue = Constants.ADD_USER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                new AppUserClaim() { Id = 6, ClaimType = Constants.ROLE_USER, ClaimValue = Constants.EDIT_USER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                new AppUserClaim() { Id = 7, ClaimType = Constants.ROLE_USER, ClaimValue = Constants.DELETE_USER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow },
                new AppUserClaim() { Id = 8, ClaimType = Constants.ROLE_USER, ClaimValue = Constants.GET_USER_CLAIM_VALUE, DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow }
                );


            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = Constants.ROLE_ADMIN, NormalizedName = Constants.ROLE_ADMIN.ToUpper() },
                new IdentityRole<int>() { Id = 2, Name = Constants.ROLE_USER, NormalizedName = Constants.ROLE_USER.ToUpper() }
                );

            var adminUser = new AppUser() { Id = 1, UserName = "admin@admin.com", Email = "admin@admin.com", FullName = "Admin", DateCreated = DateTime.UtcNow, DateModified = DateTime.UtcNow };

            adminUser.PasswordHash = new PasswordHasher<AppUser>().HashPassword(adminUser, "1234!@#$");
            builder.Entity<AppUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { UserId = 1, RoleId = 1 }
                );

            builder.Entity<IdentityUserClaim<int>>().HasData(
                new IdentityUserClaim<int>() { Id = 1, UserId = 1, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.ADD_USER_CLAIM_VALUE },
                new IdentityUserClaim<int>() { Id = 2, UserId = 1, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.EDIT_USER_CLAIM_VALUE },
                new IdentityUserClaim<int>() { Id = 3, UserId = 1, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.DELETE_USER_CLAIM_VALUE },
                new IdentityUserClaim<int>() { Id = 4, UserId = 1, ClaimType = Constants.ROLE_ADMIN, ClaimValue = Constants.GET_USER_CLAIM_VALUE },

                new IdentityUserClaim<int>() { Id = 5, UserId = 1, ClaimType = Constants.ROLE_USER, ClaimValue = Constants.ADD_USER_CLAIM_VALUE },
                new IdentityUserClaim<int>() { Id = 6, UserId = 1, ClaimType = Constants.ROLE_USER, ClaimValue = Constants.EDIT_USER_CLAIM_VALUE },
                new IdentityUserClaim<int>() { Id = 7, UserId = 1, ClaimType = Constants.ROLE_USER, ClaimValue = Constants.DELETE_USER_CLAIM_VALUE },
                new IdentityUserClaim<int>() { Id = 8, UserId = 1, ClaimType = Constants.ROLE_USER, ClaimValue = Constants.GET_USER_CLAIM_VALUE }
                );

            base.OnModelCreating(builder);
        }

        public virtual DbSet<AppUserClaim> AppUserClaim { get; set; }
    }
}