using ArchDdd.Adapters.Presentation.Abstractions.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArchDdd.Adapters.Presentation.Controllers;

//[Route("api/v{version:apiVersion}/[controller]")]
public class GreetingController(ISender sender) : ApiController(sender)
{
    [HttpGet("{name}")]
    public IActionResult Execute(string name)
    {
        return Ok(new
        {
            Hello = $"World, {name}"
        });
    }
}