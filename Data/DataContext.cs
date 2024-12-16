global using Microsoft.EntityFrameworkCore;

namespace InternshipPlatform.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<InternshipCategory> InternshipCategories { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Intern> Interns { get; set; }
        public DbSet<Internships> Internships { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<InternshipDocument> InternshipDocuments { get; set; }
        public DbSet<InternshipProgress> InternshipProgress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");




        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies(false);
                optionsBuilder.UseSqlServer("Data Source=Amine\\SQLEXPRESS;Database=InternshipDB;Trusted_Connection=true;TrustServerCertificate=true");
            }
        }

    }
}
