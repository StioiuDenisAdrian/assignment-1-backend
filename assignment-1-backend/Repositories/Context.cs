using assignment_1_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_1_backend.Repositories
{
    public class Context: IdentityDbContext<User>
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Role>().HasData(new Role { ID = 1, Name = "Administrator" });
            //modelBuilder.Entity<Role>().HasData(new Role { ID = 2, Name = "Customer" });
        }
    }
}
