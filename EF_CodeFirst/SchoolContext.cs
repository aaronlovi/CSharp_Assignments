using Microsoft.EntityFrameworkCore;

namespace EF_CodeFirst
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=SchoolDB;Trusted_Connection=True;",
                options => options.EnableRetryOnFailure());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}
