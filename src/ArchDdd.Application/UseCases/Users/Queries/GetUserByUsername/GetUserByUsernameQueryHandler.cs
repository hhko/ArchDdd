using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.Abstractions.Results;
using ArchDdd.Domain.AggregateRoots.Users.ValueObjects;
using ArchDdd.Domain.AggregateRoots.Users;
using MediatR;
using ArchDdd.Application.Abstractions;
using static ArchDdd.Domain.AggregateRoots.Users.Errors.DomainErrors;
using ArchDdd.Application.UseCases.Users.Mappings;
using ArchDdd.Application.Abstractions.Utilities;
using ArchDdd.Application.Abstractions.CQRS;

namespace ArchDdd.Application.UseCases.Users.Queries.GetUserByUsername;

internal sealed class GetUserByUsernameQueryHandler(
    IUserRepository userRepository, 
    IValidator validator)
    //: IRequestHandler<GetUserByUsernameQuery, IResult<UserResponse>>
    : IQueryHandler<GetUserByUsernameQuery, UserResponse>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IValidator _validator = validator;

    public async Task<IResult<UserResponse>> Handle(GetUserByUsernameQuery query, CancellationToken cancellationToken)
    {
        var usernameResult = Username.Create(query.Username);

        _validator
            .Validate(usernameResult);

        if (_validator.IsInvalid)
        {
            return _validator.Failure<UserResponse>();
        }

        var user = await _userRepository
            .GetByUsernameAsync(usernameResult.Value, cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserResponse>(UserError.NotFound(query.Username));
        }

        return user
            .ToResponse()
            .ToResult();
    }

    // 0. (데이터 유효성 검사)
    //      - Username
    // 1. 값 객체 생성
    //      - Username
    // 2. 비즈니스 규칙 유효성 검사: 이름 존재 유/무
    //      - _userRepository.GetByUsernameAsync
    // 3. User 반환
}