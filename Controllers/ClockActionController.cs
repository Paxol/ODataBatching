using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataBatching.Db;
using ODataBatching.Models;

namespace ODataBatching.Controllers;

[Route("api/[controller]")]
public class ClockActionController : ODataController
{
    private readonly ILogger<ClockActionController> logger;
    private readonly TestDbContext testDbContext;

    public ClockActionController(ILogger<ClockActionController> logger, TestDbContext testDbContext)
    {
        this.logger = logger;
        this.testDbContext = testDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        logger.LogInformation("Actions requested");

        var items = await testDbContext.ClockActions.ToListAsync();
        
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ClockAction clockAction)
    {
        logger.LogInformation("Adding action");

        testDbContext.ClockActions.Add(clockAction);
        await testDbContext.SaveChangesAsync();
        
        logger.LogInformation("Action added");

        return Ok(clockAction);
    }

}