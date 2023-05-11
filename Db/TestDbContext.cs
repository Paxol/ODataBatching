using Microsoft.EntityFrameworkCore;
using ODataBatching.Models;

namespace ODataBatching.Db;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> opt) : base(opt)
    {
        
    }
    
    public DbSet<ClockAction> ClockActions { get; set; }
}