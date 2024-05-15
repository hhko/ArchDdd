using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Queries.GetUserByUsername;

public sealed record UserResponse(
    Ulid Id,
    string Username,
    string Email
    //Ulid? CustomerId
) : IResponse;
// : IResponse, IHasCursor;
