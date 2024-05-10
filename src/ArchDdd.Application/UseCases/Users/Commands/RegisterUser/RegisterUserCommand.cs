using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

public sealed record RegisterUserCommand(
    string Username,
    string Email,
    string Password,
    string ConfirmPassword
//) : IRequest<IResult<RegisterUserResponse>>;
) : ICommand<RegisterUserResponse>;
