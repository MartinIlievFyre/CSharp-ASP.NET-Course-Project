using GymApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static GymApp.Common.EntityValidationConstants.RolesConstants;

namespace GymApp.Data.Configuration
{
    public class SeedUsersConfiguration : IEntityTypeConfiguration<ApplicationUser>, IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        private IPasswordHasher<ApplicationUser> _passwordHasher = new PasswordHasher<ApplicationUser>();

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .HasData(
                new ApplicationUser
                {
                    Id = Guid.Parse("f37fa09c-9247-42c4-b748-b5c8e10c6af9"),
                    UserName = "Vlado-01",
                    NormalizedUserName = "VLADO-01",
                    Email = "vlado01@abv.com",
                    PasswordHash = _passwordHasher.HashPassword(null, "test01"),
                    SecurityStamp = "SecurityStamp01"
                },
                new ApplicationUser
                {
                    Id = Guid.Parse("a82fbea5-96ff-48f0-be6f-e32f27604bff"),
                    UserName = "Monika-02",
                    NormalizedUserName = "MONIKA-02",
                    Email = "monika02@abv.com",
                    PasswordHash = _passwordHasher.HashPassword(null, "test02"),
                    SecurityStamp = "SecurityStamp02"
                },
                new ApplicationUser
                {
                    Id = Guid.Parse("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                    UserName = "Preslav-03",
                    NormalizedUserName = "PRESLAV-03",
                    Email = "presko-03@abv.com",
                    PasswordHash = _passwordHasher.HashPassword(null, "test03"),
                    SecurityStamp = "SecurityStamp03"
                },
                new ApplicationUser
                {
                    Id = Guid.Parse("a17550b2-729b-4a14-afdb-738804dbf7f2"),
                    UserName = AdminUserName,
                    NormalizedUserName = AdminUserName,
                    Email = AdminEmail,
                    PasswordHash = _passwordHasher.HashPassword(null, AdminPassword),
                    SecurityStamp = "SecurityStamp04"
                });

        }
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder
                .HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse(UserId),
                    UserId = Guid.Parse("f37fa09c-9247-42c4-b748-b5c8e10c6af9")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse(UserId),
                    UserId = Guid.Parse("a82fbea5-96ff-48f0-be6f-e32f27604bff")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse(UserId),
                    UserId = Guid.Parse("cbef4ddc-5788-48ab-9380-aa457c89a554")
                },
                new IdentityUserRole<Guid>
                {
                    RoleId = Guid.Parse(AdminId),
                    UserId = Guid.Parse("a17550b2-729b-4a14-afdb-738804dbf7f2")
                });
        }
    }
}
