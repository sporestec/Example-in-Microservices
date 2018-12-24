using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberOne.API.Models
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {
        }
        public DbSet<UserData> Users { get; set; }


        public class CatalogContextDesignFactory : IDesignTimeDbContextFactory<UserDataContext>
        {
            public UserDataContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UserDataContext>()
                    .UseSqlServer("Server=tcp:127.0.0.1,5433;Initial Catalog=numberoneDB;User Id=sa;Password=Pass@word");

                return new UserDataContext(optionsBuilder.Options);
            }
        }
    }
}
