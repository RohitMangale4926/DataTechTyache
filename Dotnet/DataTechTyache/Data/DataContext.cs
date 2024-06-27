using Microsoft.EntityFrameworkCore;
using datatechtyache.Models;

namespace datatechtyache.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Temp_PrintPlan> Temp_PrintPlans   { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Temp_PrintPlan>()
                .ToTable("Temp_PrintPlan", schema: "Tyache") // Specify the schema here
                .HasKey(tp => tp.TempPlanID); // Ensure primary key is set

            modelBuilder.Entity<Temp_PrintPlan>()
                .Property(p => p.TempPlanID)
                .ValueGeneratedOnAdd(); // Auto-generate TempPrintPlanID
        }
    }
}
