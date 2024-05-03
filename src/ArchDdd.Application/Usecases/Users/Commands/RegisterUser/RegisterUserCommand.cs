using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

public sealed record RegisterUserCommand(
    string Username,
    string Email,
    string Password,
    string ConfirmPassword

) : IRequest<IResult<RegisterUserResponse>>;