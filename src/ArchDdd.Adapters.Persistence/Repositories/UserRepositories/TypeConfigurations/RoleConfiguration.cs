using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using static ArchDdd.Adapters.Persistence.Abstractions.Constants.Constants;
using Microsoft.AspNetCore.Http.HttpResults;
using ArchDdd.Domain.AggregateRoots.Users.Enumerations;

namespace ArchDdd.Adapters.Persistence.Repositories.UserRepositories.TypeConfigurations;


// CREATE TABLE "Role" (
//     "Name" VarChar(128) NOT NULL CONSTRAINT "PK_Role" PRIMARY KEY
// )

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        //
        // 테이블
        //

        builder.ToTable(TableName.Role, SchemaName.Master);
        builder.HasKey(r => r.Name);

        //
        // 컬럼
        //

        builder.Property(r => r.Name)
            .HasColumnType(ColumnType.VarChar(128));

        //
        // 관계
        //

        //builder.HasMany(x => x.Permissions)
        //    .WithMany()
        //    .UsingEntity<RolePermission>();

        builder.HasMany(r => r.Users)
            .WithMany(u => u.Roles);

        //
        // 데이터
        //

        var predefinedRoles = Role.GetPredefinedRoles();
        //var rolesFromEnum = GetNamesOf<RoleName>();

        //bool areEnumRolesEquivalentToPredefinedRoles = predefinedRoles
        //    .Select(x => x.Name)
        //    .SequenceEqual(rolesFromEnum);

        //if (areEnumRolesEquivalentToPredefinedRoles is false)
        //{
        //    throw new Exception($"{nameof(Role)} enum values are not equivalent to predefined {nameof(Role)}s");
        //}

        ////Insert static data
        builder.HasData(predefinedRoles);
    }
}
