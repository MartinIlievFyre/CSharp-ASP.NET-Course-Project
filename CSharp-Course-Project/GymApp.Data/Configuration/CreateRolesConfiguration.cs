using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GymApp.Common.EntityValidationConstants.RolesConstants;
namespace GymApp.Data.Configuration
{
    public class CreateRolesConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {

            builder
                .HasData(new IdentityRole<Guid> { Id = Guid.Parse(UserId), Name = NameOfRoleUser, NormalizedName = NameOfRoleUser.ToUpper() });
          
            builder
                .HasData(new IdentityRole<Guid> { Id = Guid.Parse(AdminId), Name = NameOfRoleAdmin, NormalizedName = NameOfRoleAdmin.ToUpper() });
        }
    }
}
