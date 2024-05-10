using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

public sealed record RegisterUserResponse(
    string Id
) : IResponse;
