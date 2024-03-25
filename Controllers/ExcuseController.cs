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

    [HttpGet("{id}", Name = "GetExcuseById")]
    public Excuse GetExcuseById(int id)
    {
        return ExcuseService.GetExcuse(id);
    }
}
