using DockerizedNetPostgresApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerizedNetPostgresApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }
    }
}
