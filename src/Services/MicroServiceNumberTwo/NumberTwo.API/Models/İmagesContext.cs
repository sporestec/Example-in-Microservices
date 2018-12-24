using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberTwo.API.Models
{
    public class İmagesContext : DbContext
    {
        public İmagesContext(DbContextOptions<İmagesContext> options) : base(options)
        {
        }
        public DbSet<UsersImages> Users { get; set; }


        public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<İmagesContext>
        {
            public İmagesContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<İmagesContext>()
                    .UseSqlServer("Server=tcp:127.0.0.1,5433;Initial Catalog=numbertwoDB;User Id=sa;Password=Pass@word");

                return new İmagesContext(optionsBuilder.Options);
            }
        }
    }
}
