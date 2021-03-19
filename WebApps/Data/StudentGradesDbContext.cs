namespace WebApps.Data
{
    using ConsoleAppProject.App03;
    using Microsoft.EntityFrameworkCore;

    public class StudentGradesDbContext : DbContext
    {
        public StudentGradesDbContext(DbContextOptions<StudentGradesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
