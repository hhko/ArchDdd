using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using MediatR;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

internal sealed class RegisterUserCommandHandler
    : IRequestHandler<RegisterUserCommand, IResult<RegisterUserResponse>>
{
    public async Task<IResult<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        return Result.Success(new RegisterUserResponse(Ulid.NewUlid()));
    }
}
