using KM_KT3120.Database.Configurations;
using KM_KT3120.Models;
using Microsoft.EntityFrameworkCore;

namespace KM_KT3120.Database
{
    public class KondratevDbContext: DbContext 

    {
        internal DbSet<Student> Students { get; set; }
        internal DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
        public KondratevDbContext(DbContextOptions<KondratevDbContext> options) : base(options) { }
    }
}
