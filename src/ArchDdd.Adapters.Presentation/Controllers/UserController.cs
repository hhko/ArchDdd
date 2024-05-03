using ArchDdd.Adapters.Presentation.Abstractions.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using ArchDdd.Application.UseCases.Users.Commands.RegisterUser;
using MediatR;

namespace ArchDdd.Adapters.Presentation.Controllers;

public class UserController(ISender sender) : ApiController(sender)
{
    [HttpPost("[action]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest)]
    public async Task<Results<Ok<string>, ProblemHttpResult>> Register(
        [FromBody] RegisterUserCommand command,
        CancellationToken cancellationToken)
    {
        var result = await Sender.Send(command, cancellationToken);

        //if (result.IsFailure)
        //{
        //    return HandleFailure(result);
        //}

        //return TypedResults.Ok(result.Value);

        //return TypedResults.Ok(new RegisterUserResponse(Ulid.NewUlid()));
        return TypedResults.Ok(result.Value.Id);
    }
}
