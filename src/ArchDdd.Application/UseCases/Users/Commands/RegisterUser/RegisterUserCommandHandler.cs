using ArchDdd.Application.Abstractions;
using ArchDdd.Application.Abstractions.Utilities;
using ArchDdd.Application.UseCases.Users.Mappings;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

internal sealed class RegisterUserCommandHandler(
    IUserRepository userRepository,
    IValidator validator,
    IPasswordHasher<User> passwordHasher)
    : IRequestHandler<RegisterUserCommand, IResult<RegisterUserResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IValidator _validator = validator;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;

    public async Task<IResult<RegisterUserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        ValidationResult<Email> emailResult = Email.Create(request.Email);
        ValidationResult<Username> usernameResult = Username.Create(request.Username);
        ValidationResult<Password> passwordResult = Password.Create(request.Password);

        // 메일 중복?
        //bool emailIsTaken = await _userRepository
        //    .IsEmailTakenAsync(emailResult.Value, cancellationToken);

        _validator
            .Validate(emailResult)
            .Validate(usernameResult)
            .Validate(passwordResult);
            //.If(emailIsTaken, thenError: EmailError.EmailAlreadyTaken);

        if (_validator.IsInvalid)
        {
            return _validator.Failure<RegisterUserResponse>();
        }

        //return Result.Success(new RegisterUserResponse(Ulid.NewUlid().ToString()));

        var result = RegisterUser(emailResult.Value, usernameResult.Value, passwordResult.Value);

        return result;
    }

    private IResult<RegisterUserResponse> RegisterUser(Email email, Username username, Password password)
    {
        var user = User.Create(UserId.New(), username, email);

        ValidationResult<PasswordHash> passwordHashResult = PasswordHash.Create(_passwordHasher.HashPassword(user, password.Value));
        _validator
            .Validate(passwordHashResult);

        if (_validator.IsInvalid)
        {
            return _validator.Failure<RegisterUserResponse>();
        }

        user.SetHashedPassword(passwordHashResult.Value);

        _userRepository.Add(user);

        return user
            .ToCreateResponse()
            .ToResult();
    }
}
