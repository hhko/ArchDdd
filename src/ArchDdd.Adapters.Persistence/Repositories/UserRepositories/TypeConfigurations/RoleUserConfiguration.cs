using ArchDdd.Adapters.Persistence.Repositories.Converters.EntityIds;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static ArchDdd.Adapters.Persistence.Abstractions.Constants.Constants;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

namespace ArchDdd.Adapters.Persistence.Repositories.UserRepositories.TypeConfigurations;

// CREATE TABLE "RoleUser" (
//     "RoleName" VarChar(128) NOT NULL,
//     "UserId" Char(26) NOT NULL,
//     CONSTRAINT "PK_RoleUser" PRIMARY KEY("RoleName", "UserId"),
//     CONSTRAINT "FK_RoleUser_Role_RoleName" FOREIGN KEY("RoleName") REFERENCES "Role" ("Name") ON DELETE CASCADE,
//     CONSTRAINT "FK_RoleUser_User_UserId" FOREIGN KEY("UserId") REFERENCES "User" ("Id") ON DELETE CASCADE
// )

internal class RoleUserConfiguration : IEntityTypeConfiguration<RoleUser>
{
    public void Configure(EntityTypeBuilder<RoleUser> builder)
    {
        // 테이블
        builder.ToTable(TableName.RoleUser, SchemaName.Master);
        builder.HasKey(x => new { x.RoleName, x.UserId });

        // 컬럼
        builder.Property(x => x.RoleName)
            .HasColumnType(ColumnType.VarChar(128));

        builder.Property(x => x.UserId)
            .HasConversion<UserIdConverter, UserIdComparer>()
            .HasColumnType(ColumnType.Char(Number.UlidCharLenght));
    }
}