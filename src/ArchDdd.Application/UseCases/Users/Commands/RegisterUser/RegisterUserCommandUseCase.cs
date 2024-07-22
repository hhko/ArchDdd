using ArchDdd.Application.Abstractions;
using ArchDdd.Application.Abstractions.CQRS;
using ArchDdd.Application.Abstractions.Utilities;
using ArchDdd.Application.UseCases.Users.Mappings;
using ArchDdd.Application.UseCases.Users.Queries;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using Microsoft.AspNetCore.Identity;
using static ArchDdd.Domain.AggregateRoots.Users.Errors.DomainErrors;

namespace ArchDdd.Application.UseCases.Users.Commands.RegisterUser;

internal sealed class RegisterUserCommandUseCase(
    IUserRepositoryCommand userRepositoryCommand,
    IUserRepositoryQuery userRepositoryQuery,
    IPasswordHasher<User> passwordHasher,
    IValidator validator)
    //: IRequestHandler<RegisterUserCommand, IResult<RegisterUserResponse>>
    : ICommandUseCase<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IUserRepositoryCommand _userRepositoryCommand = userRepositoryCommand;
    private readonly IUserRepositoryQuery _userRepositoryQuery = userRepositoryQuery;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    private readonly IValidator _validator = validator;

    public async Task<IResult<RegisterUserResponse>> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
    {
        // 도메인 객체 생성
        Email email = Email.Create(command.Email).Value;
        Username username = Username.Create(command.Username).Value;
        Password password = Password.Create(command.Password).Value;

        // 도메인 객체 유/무: 비즈니스 규칙
        bool emailIsTaken = await _userRepositoryQuery.IsEmailTakenAsync(email, cancellationToken);

        _validator.If(
            condition: emailIsTaken,
            thenError: EmailError.EmailAlreadyTaken(email));
        if (_validator.IsInvalid)
        {
            return _validator.Failure<RegisterUserResponse>();
        }

        // 도메인 객체 생성
        return RegisterUser(email, username, password);
    }

    private IResult<RegisterUserResponse> RegisterUser(Email email, Username username, Password password)
    {
        var user = User.Create(UserId.New(), username, email);

        // 비즈니스 유효성
        ValidationResult<PasswordHash> passwordHashResult = PasswordHash.Create(_passwordHasher.HashPassword(user, password.Value));

        _validator.Validate(passwordHashResult);
        
        if (_validator.IsInvalid)
        {
            return _validator.Failure<RegisterUserResponse>();
        }

        user.SetHashedPassword(passwordHashResult.Value);
        _userRepositoryCommand.Add(user);

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
