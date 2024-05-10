using ArchDdd.Application.Abstractions;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

internal sealed class RegisterUserCommandHandler(
    IValidator validator)
    : IRequestHandler<RegisterUserCommand, IResult<RegisterUserResponse>>
{
    private readonly IValidator _validator = validator;

    public async Task<IResult<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        //ValidationResult<Email> emailResult = Email.Create(request.Email);
        ValidationResult<Username> usernameResult = Username.Create(request.Username);
        //ValidationResult<Password> passwordResult = Password.Create(request.Password);

        //bool emailIsTaken = await _userRepository
        //    .IsEmailTakenAsync(emailResult.Value, cancellationToken);

        _validator
            //.Validate(emailResult)
            .Validate(usernameResult);
            //.Validate(passwordResult)
            //.If(emailIsTaken, thenError: EmailError.EmailAlreadyTaken);

        if (_validator.IsInvalid)
        {
            return _validator.Failure<RegisterUserResponse>();
        }

        await Task.CompletedTask;

        return Result.Success(new RegisterUserResponse(Ulid.NewUlid().ToString()));
    }
}
