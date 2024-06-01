using ArchDdd.Application.Abstractions;
using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Application.Abstractions.Utilities;
using ArchDdd.Application.UseCases.Users.Mappings;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Identity;
using static ArchDdd.Domain.AggregateRoots.Users.Errors.DomainErrors;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

internal sealed class RegisterUserCommandUseCase(
    IUserRepository userRepository,
    IPasswordHasher<User> passwordHasher,
    IValidator validator)
    //: IRequestHandler<RegisterUserCommand, IResult<RegisterUserResponse>>
    : ICommandUseCase<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    private readonly IValidator _validator = validator;

    public async Task<IResult<RegisterUserResponse>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        Email email = Email.Create(command.Email).Value;
        Username username = Username.Create(command.Username).Value;
        Password password = Password.Create(command.Password).Value;

        bool emailIsTaken = await _userRepository
            .IsEmailTakenAsync(email, cancellationToken);

        _validator
            .If(emailIsTaken, thenError: EmailError.EmailAlreadyTaken(email));

        if (_validator.IsInvalid)
        {
            return _validator.Failure<RegisterUserResponse>();
        }

        return RegisterUser(email, username, password);
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

    // 0. (데이터 유효성 검사)
    //      - Username
    //      - Email
    //      - Password
    //        -> PasswordHash
    // 1. 값 객체 생성
    //      - Username
    //      - Email
    //      - Password
    //        -> PasswordHash
    // 2. 비즈니스 규칙 유효성 검사: 메일 존재 유/무
    //      - _userRepository.IsEmailTakenAsync
    // 3. User 생성
    // 4. User 추가       
    //      - Db 저장?
    // 5. User Id 반환
}
