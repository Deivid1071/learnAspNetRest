using Microsoft.EntityFrameworkCore;

namespace RestWithASPNETUdemy.Model.Context
{
    public class PostgresContext : DbContext
    {
        public PostgresContext()
        {

        }

        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
