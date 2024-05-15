using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

public sealed record RegisterUserResponse(
    Ulid Id
) : IResponse;
