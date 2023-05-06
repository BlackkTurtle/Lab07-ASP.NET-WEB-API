using Lab07_ASP.NET_WEB_API.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab07_ASP.NET_WEB_API.Data
{
    public class TablesContext : DbContext
    {
        public TablesContext(DbContextOptions<TablesContext> options) : base(options)
        {

        }
        public DbSet<Table1> table1s => Set<Table1>();
        public DbSet<Table2> table2s => Set<Table2>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table1>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Table1s");
                entity.Property(e => e.Name);
            });

            modelBuilder.Entity<Table2>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Table2s");

                entity.Property(e => e.Name);
                entity.HasOne(d => d.Table1).WithMany(p => p.Table2s)
                    .HasForeignKey(d => d.Table1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table2s_Table1s");
            });
        }
    }
}
