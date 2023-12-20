using Microsoft.EntityFrameworkCore;
using webAPICaching.Model;

namespace webAPICaching.Data
{
    public class MovieDBContext : DbContext
    {

        public MovieDBContext(DbContextOptions<MovieDBContext> option):base(option) { }

        public DbSet<Movies> MovieTable { get; set; }
    }
}
