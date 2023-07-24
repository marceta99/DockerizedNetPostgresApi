using DockerizedNetPostgresApi.Data;
using DockerizedNetPostgresApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerizedNetPostgresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private ApiDbContext _dbContext;
        public DriverController(ApiDbContext apiDbContext)
        {
            _dbContext = apiDbContext;
        }

        [HttpGet("GetAllDrivers")]
        public async Task<IActionResult> Get()
        {
            var driver = new Driver
            { 
                DriverNumber = 44, 
                Name = "Sir Levis Hamilton"
            };
            _dbContext.Add(driver);
            await _dbContext.SaveChangesAsync();


            var allDrivers = await _dbContext.Drivers.ToListAsync();
            return Ok(allDrivers);
        }
        
    }
}
