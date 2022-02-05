﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace ARTech.Server.Configurations.Entities
{
    public class UserRoleSeedConfiguration :
    IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void
       Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "ad2bcf0c-20db-474f-8407-5a6b159518ba",
                UserId = "3781efa7-66dc-47f0-860f-e506d04102e4"
            },
            new IdentityUserRole<string>
            {
                RoleId = "bd2bcf0c-20db-474f-8407-5a6b159518bb",
                UserId = "s6d9f4v0-e72c-12es-0971-es2d21f0e898"

            }
            );
        }
    }
}