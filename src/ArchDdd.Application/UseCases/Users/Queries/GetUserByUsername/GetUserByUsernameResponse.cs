using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Queries.GetUserByUsername;

public sealed record GetUserByUsernameResponse(
    //Ulid Id,
    string Id,
    string Username,
    string Email
    //Ulid? CustomerId
) : IResponse;
// : IResponse, IHasCursor;