using Notes.Models;
using Microsoft.EntityFrameworkCore;

namespace GB_Market.DB
{
    public class NotesContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        private string _connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("appsettings.json");
            var cfg = config.Build();
            _connectionString = cfg.GetConnectionString("db");
            optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("note_pkey");

                entity.ToTable("notes");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CreatedDate)
                    .HasMaxLength(255)
                    .HasColumnName("create_date");
                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");
                entity.Property(e => e.Description)
                    .HasMaxLength(1024)
                    .HasColumnName("description");
            });
        }
    }
}
