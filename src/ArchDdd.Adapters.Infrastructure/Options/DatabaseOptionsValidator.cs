using FluentValidation;
using Microsoft.Extensions.Options;

namespace ArchDdd.Adapters.Infrastructure.Options;

public class DatabaseOptionsValidator : AbstractValidator<DatabaseOptions>
{
    public DatabaseOptionsValidator()
    {
        RuleFor(x => x.ConnectionString).NotEmpty();
        RuleFor(x => x.MaxRetryCount).GreaterThan(0);
        RuleFor(x => x.MaxRetryDelay).GreaterThan(0);
        RuleFor(x => x.CommandTimeout).GreaterThan(0);
    }
}