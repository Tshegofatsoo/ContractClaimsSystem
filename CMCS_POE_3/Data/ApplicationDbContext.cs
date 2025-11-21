using ContractClaimsSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ContractClaimsSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}
