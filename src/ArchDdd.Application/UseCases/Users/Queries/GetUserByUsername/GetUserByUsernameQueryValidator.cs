using ArchDdd.Application.Abstractions.Utilities;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using FluentValidation;

namespace ArchDdd.Application.UseCases.Users.Queries.GetUserByUsername;

internal sealed class GetUserByUsernameQueryValidator : AbstractValidator<GetUserByUsernameQuery>
{
    public GetUserByUsernameQueryValidator()
    {
        RuleFor(x => x.Username)
            .MustSatisfyValueObjectValidation(Username.Validate);
    }
}
