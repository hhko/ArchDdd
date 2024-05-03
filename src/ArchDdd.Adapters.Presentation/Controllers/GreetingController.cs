using ArchDdd.Adapters.Presentation.Abstractions.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArchDdd.Adapters.Presentation.Controllers;

//[ApiController]
////[Route("api/[controller]")]
//[ApiVersion(1.0, Deprecated = true)]
//[ApiVersion(2.0)]
//[Route("api/v{version:apiVersion}/[controller]")]
public class GreetingController(ISender sender) : ApiController(sender)
//public class GreetingController : ApiController
{
    //public GreetingController()
    //{
        
    //}

    [HttpGet("{name}")]
    public IActionResult Execute(string name)
    {
        return Ok(new
        {
            Hello = $"World, {name}"
        });
    }
}