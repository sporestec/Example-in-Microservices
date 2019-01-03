using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberTwo.API.Models
{
    public class ImagesContext : DbContext
    {
        public ImagesContext(DbContextOptions<ImagesContext> options) : base(options)
        {
        }
        public DbSet<UserImage> UsersImages { get; set; }


        public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<ImagesContext>
        {
            public ImagesContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ImagesContext>()
                    .UseSqlServer("Server=tcp:127.0.0.1,5433;Initial Catalog=numbertwoDB;User Id=sa;Password=Pass@word");

                return new ImagesContext(optionsBuilder.Options);
            }
        }
    }
}
