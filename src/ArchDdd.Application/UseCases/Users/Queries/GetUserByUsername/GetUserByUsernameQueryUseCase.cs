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
using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using ArchDdd.Domain.Abstractions.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

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
        // info: Microsoft.EntityFrameworkCore.Database.Command[20101]
        //       Executed DbCommand(13ms) [
        //          Parameters= [
        //              p0 = 'Lucas'(Size = 5)
        //          ],
        //          CommandType = 'Text',
        //          CommandTimeout = '1'
        //       ]
        //       SELECT "a"."Email", "a"."Id", "a"."Username"                   <-- 제거 방법은?
        //       FROM(
        //           SELECT "u"."Id", "u"."Username", "u"."Email"
        //               FROM "User" AS "u"
        //               WHERE "u"."Username" = @p0
        //               LIMIT 1
        //       ) AS "a"
        //       LIMIT 1
        var response = await _userRepository.SqlQuerySingleAsync<GetUserByUsernameResponse>($"""
            SELECT "u"."Id", "u"."Username", "u"."Email"
                FROM "User" AS "u"
                WHERE "u"."Username" = {query.Username}
                LIMIT 1
            """, cancellationToken);

        _validator.If(
            condition: response is null,
            thenError: UserError.NotFound(query.Username));
        if (_validator.IsInvalid)
        {
            return _validator.Failure<GetUserByUsernameResponse>();
        }

        return response!.ToResult();
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