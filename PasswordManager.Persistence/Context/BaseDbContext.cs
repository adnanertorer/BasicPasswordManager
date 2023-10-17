using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PasswordManager.Domain.Entities;
using System.Reflection;

namespace PasswordManager.Persistence.Context
{
    public class BaseDbContext: DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public BaseDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserNote> UserNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
