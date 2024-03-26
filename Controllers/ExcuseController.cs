using Microsoft.AspNetCore.Mvc;

namespace excuse_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExcuseController : ControllerBase
{
    private readonly ILogger<ExcuseController> _logger;

    public ExcuseController(ILogger<ExcuseController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id:int}", Name = "GetExcuseById")]
    public Excuse GetExcuseById(int id)
    {
        return ExcuseService.GetExcuse(id);
    }

    [HttpGet(Name = "GetRandomExcuse")]
    public Excuse GetRandomExcuse()
    {
        return ExcuseService.GetRandomExcuse();
    }

    /// <summary>
    /// Gets excuses that have the given 'searchString'
    /// Ex. "machine" matches "it worked on my machine" and "there are bugs in the machine"
    /// </summary>
    [HttpGet("{searchString}", Name = "GetExcusesByQuery")] 
    public List<Excuse> GetExcusesByQuery(string searchString)
    {
        return ExcuseService.GetExcusesByQuery(searchString);
    }
}
