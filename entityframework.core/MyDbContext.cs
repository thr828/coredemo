
using Microsoft.EntityFrameworkCore;
namespace entityframework.core
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}