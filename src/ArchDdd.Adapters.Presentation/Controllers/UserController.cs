using ArchDdd.Adapters.Presentation.Abstractions.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using MediatR;
using ArchDdd.Domain.Abstractions.Results.Contracts;
using ArchDdd.Application.UseCases.Users.Queries.GetUserByUsername;
using ArchDdd.Adapters.Presentation.Abstractions.Utilities;

namespace ArchDdd.Adapters.Presentation.Controllers;

public class UserController(ISender sender) : ApiController(sender)
{
    // POST {{host}}/api/user/register
    // content-type: application/json
    // 
    // {
    //     "username": "Lucas",
    //     "email": "lucas@fun.com",
    //     "password": "123456789#aB",
    //     "confirmPassword": "123456789#aB"
    // }
    [HttpPost("[action]")]
    [ProducesResponseType<RegisterUserResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<RegisterUserResponse>, ProblemHttpResult>> Register(
        [FromBody] RegisterUserCommand command,
        CancellationToken cancellationToken)
    {
        IResult<RegisterUserResponse> result = await Sender.Send(command, cancellationToken);

        return result.IsSuccess
            ? result.ToOkResult()
            : result.ToProblemHttpResult();
    }

    // GET {{host}}/api/user/Lucas
    [HttpGet("{username}")]
    [ProducesResponseType<GetUserByUsernameResponse>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<GetUserByUsernameResponse>, ProblemHttpResult>> GetUserByUsername(
        [FromRoute] string username,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(
            new GetUserByUsernameQuery(username),
            cancellationToken);

        return result.IsSuccess
            ? result.ToOkResult()
            : result.ToProblemHttpResult();
    }

    //[HttpPost("roles/{role}/permissions/{permission}")]
    ////[RequiredRoles(Domain.Enums.Role.Administrator)]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    //public async Task<Results<Ok, ProblemHttpResult>> AddPermissionToRole(
    //    [FromRoute] string role,
    //    [FromRoute] string permission,
    //    CancellationToken cancellationToken)
    //{
    //    var command = new AddPermissionToRoleCommand(role, permission);
    //    var result = await Sender.Send(command, cancellationToken);

    //    return result.IsSuccess
    //        ? result.ToOkResult()
    //        : result.ToProblemHttpResult();
    //}

    

    //// POST /api/{username}/roles/{customer}
    //[HttpPost("{username}/roles/{role}")]
    ////[RequiredRoles(RoleName.Administrator)]
    //[ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    //public async Task<Results<Ok, ProblemHttpResult>> AddRoleToUser
    //(
    //    [FromRoute] string username,
    //    [FromRoute] string role,
    //    CancellationToken cancellationToken
    //)
    //{
    //    var command = new AddRoleToUserCommand(username, role);
    //    var result = await Sender.Send(command, cancellationToken);

    //    return result.IsFailure
    //        ? result.ToOkResult()
    //        : result.ToProblemHttpResult();
    //}
}
