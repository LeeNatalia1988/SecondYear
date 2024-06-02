using Microsoft.EntityFrameworkCore;
using MessageWorker.DbModels;

namespace MessageWorker.Db
{
    public partial class MessageContext : DbContext
    {
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MessageStatus> MessageStatus { get; set; }
        
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
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("messages_pkey");
                entity.HasIndex(e => e.Id).IsUnique();

                entity.ToTable("messages");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Text).HasMaxLength(510).HasColumnName("text");
                entity.Property(e => e.FromUser).HasMaxLength(255).HasColumnName("from_user");
                entity.Property(e => e.ToUser).HasMaxLength(255).HasColumnName("to_user");
                
                entity.Property(e => e.StatusID).HasConversion<int>();
            });

            modelBuilder.Entity<MessageStatus>().Property(e => e.MessageStatusID).HasConversion<int>();

            modelBuilder.Entity<MessageStatus>()
                .HasData(Enum.GetValues(typeof(MessageStatusID))
                .Cast<MessageStatusID>()
                .Select(e => new MessageStatus()
            {
                MessageStatusID = e,
                Text = e.ToString()
            }));
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
