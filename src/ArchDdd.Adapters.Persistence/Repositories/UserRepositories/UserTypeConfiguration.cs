using ArchDdd.Adapters.Persistence.Repositories.Converters.EntityIds;
using ArchDdd.Adapters.Persistence.Repositories.Converters.ValueObjects;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static ArchDdd.Adapters.Persistence.Abstractions.Constants.Constants;

namespace ArchDdd.Adapters.Persistence.Repositories.UserRepositories;

internal sealed class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // -------------------
        // 테이블
        // -------------------
        // ToTable

        // -------------------
        // 컬럼
        // -------------------
        // Property
        //
        // HasKey
        // HasConversion
        // HasColumnType
        // HasColumnName
        // HasMaxLength
        //
        // IsRequired

        // -------------------
        // 관계
        // -------------------
        // HasMany
        // HasOne
        // HasForeignKey
        //
        // WithMany
        // WithOne
        //
        // UsingEntity

        // -------------------
        // 인덱스
        // -------------------
        // HasIndex
        // HasDatabaseName
        //
        // IsUnique

        // -------------------------
        // 테이블
        // -------------------------

        builder.ToTable(TableName.User, SchemaName.Master);

        // -------------------------
        // 컬럼
        // -------------------------

        // Id
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Id)
            .HasConversion<UserIdConverter, UserIdComparer>()
            .HasColumnType(ColumnType.Char(Number.UlidCharLenght));

        // ?
        //builder.ConfigureAuditableEntity();

        builder.Property(u => u.Username)
            .HasConversion<UsernameConverter, UsernameComparer>()
            .HasColumnName(nameof(Username))
            .HasMaxLength(Username.MaxLength)
            .IsRequired(true);

        builder.Property(u => u.Email)
            .HasConversion<EmailConverter, EmailComparer>()
            .HasColumnName(nameof(Email))
            .HasMaxLength(Email.MaxLength)
            .IsRequired(true);

        builder.Property(u => u.PasswordHash)
            .HasConversion<PasswordHashConverter, PasswordHashComparer>()
            .HasColumnName(nameof(PasswordHash))
            .HasColumnType(ColumnType.NChar(PasswordHash.BytesLong))
            .IsRequired(true);

        //builder.Property(u => u.RefreshToken)
        //    .HasConversion<RefreshTokenConverter, RefreshTokenComparer>()
        //    .HasColumnName(nameof(RefreshToken))
        //    .HasColumnType(ColumnType.VarChar(RefreshToken.Length))
        //    .IsRequired(false);

        //builder.Property(u => u.TwoFactorTokenHash)
        //    .HasConversion<TwoFactorTokenHashConverter, TwoFactorTokenHashComparer>()
        //    .HasColumnName(nameof(TwoFactorTokenHash))
        //    .HasColumnType(ColumnType.NChar(TwoFactorTokenHash.BytesLong))
        //    .IsRequired(false);

        //builder.Property(u => u.TwoFactorToptSecret)
        //    .HasConversion<TwoFactorToptSecretConverter, TwoFactorToptSecretComparer>()
        //    .HasColumnName(nameof(TwoFactorToptSecret))
        //    .HasColumnType(ColumnType.Char(TwoFactorToptSecret.BytesLong))
        //    .IsRequired(false);

        //builder.Property(entity => entity.TwoFactorTokenCreatedOn)
        //    .HasColumnType(ColumnType.DateTimeOffset(2))
        //    .IsRequired(false);

        // -------------------------
        // 관계
        // -------------------------

        //builder.HasMany(u => u.Roles)
        //    .WithMany(r => r.Users)
        //    .UsingEntity<RoleUser>();

        //builder.HasMany<OrderHeader>()
        //    .WithOne()
        //    .HasForeignKey(u => u.UserId);

        //builder.HasOne(u => u.Customer)
        //    .WithOne(c => c.User)
        //    .HasForeignKey<User>(u => u.CustomerId);

        // -------------------------
        // 인덱스
        // -------------------------

        //builder
        //    .HasIndex(user => user.Username)
        //    .HasDatabaseName($"UX_{nameof(Username)}_{nameof(Email)}")
        //    // Microsoft.EntityFrameworkCore.SqlServer.Metadata.Internal
        //    //.IncludeProperties(user => user.Email)
        //    .IsUnique(true);

        //builder
        //    .HasIndex(user => user.Email)
        //    .HasDatabaseName($"UX_{nameof(User)}_{nameof(Email)}")
        //    .IsUnique(true);
    }
}
