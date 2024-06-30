using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Domain.AggregateRoots.Users;
using ArchDdd.Application.Abstractions;
using static ArchDdd.Domain.AggregateRoots.Users.Errors.DomainErrors;
using ArchDdd.Application.Abstractions.Utilities;
using ArchDdd.Application.Abstractions.CQRS;
using System.Threading;

namespace ArchDdd.Application.UseCases.Users.Queries.GetUserByUsername;

internal sealed class GetUserByUsernameQueryUseCase(
    IUserRepository userRepository, 
    IValidator validator)
    // 이전: IResult 출력 타입 단순화
    //  : IRequestHandler<GetUserByUsernameQuery, IResult<UserResponse>>
    : IQueryUseCase<GetUserByUsernameQuery, GetUserByUsernameResponse>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IValidator _validator = validator;

    public async Task<IResult<GetUserByUsernameResponse>> Handle(GetUserByUsernameQuery query, CancellationToken cancellationToken)
    {
        var response = await _userRepository.SqlQuerySingleAsync<GetUserByUsernameResponse>(
            QueryUserByUsername(query.Username),
            cancellationToken);

        _validator.If(
            condition: response is null,
            thenError: UserError.NotFound(query.Username));
        if (_validator.IsInvalid)
        {
            return _validator.Failure<GetUserByUsernameResponse>();
        }

        return response!.ToResult();
    }

    private FormattableString QueryUserByUsername(string username)
    {
        return $"""
            SELECT u.Id, u.Username, u.Email
                FROM User AS u
                WHERE u.Username = {username}
                LIMIT 1
            """;
    }

    //public async Task<IResult<GetUserByUsernameResponse>> Handle(GetUserByUsernameQuery query, CancellationToken cancellationToken)
    //{
    //    Username username = Username.Create(query.Username).Value;

    //    // info: Microsoft.EntityFrameworkCore.Database.Command[20101]
    //    //       Executed DbCommand(18ms) [
    //    //          Parameters= [
    //    //              @__username_0 = 'Lucas'(Size = 5)
    //    //          ],
    //    //          CommandType = 'Text',
    //    //          CommandTimeout = '1'
    //    //       ]
    //    //       SELECT "u"."Id", "u"."CreatedOn", "u"."Email", "u"."PasswordHash", "u"."UpdatedOn", "u"."Username"
    //    //       FROM "User" AS "u"
    //    //       WHERE "u"."Username" = @__username_0
    //    //       LIMIT 1

    //    User? user = await _userRepository
    //        .GetByUsernameAsync(username, cancellationToken);

    //    _validator.If(
    //        condition: user is null,
    //        thenError: UserError.NotFound(query.Username));
    //    if (_validator.IsInvalid)
    //    {
    //        return _validator.Failure<GetUserByUsernameResponse>();
    //    }

    //    return user!
    //        .ToResponse()
    //        .ToResult();
    //}

    //public static class UserMapping
    //{
    //    public static GetUserByUsernameResponse ToResponse(this User user)
    //    {
    //        return new GetUserByUsernameResponse(
    //            user.Id.Value,
    //            user.Username.Value,
    //            user.Email.Value
    //        //user.CustomerId?.Value
    //        );
    //    }
    //}
}