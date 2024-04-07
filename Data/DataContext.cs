using Microsoft.EntityFrameworkCore;
using MinimalApi.Model;

namespace MinimalApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
    }
}
