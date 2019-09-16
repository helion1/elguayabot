using ElGuayabot.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ElGuayabot.Persistence.Implementation.Context
{
    public partial class ElGuayabotDbContext : DbContext
    {
        protected ElGuayabotDbContext()
        {
        }

        public ElGuayabotDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; }
        
        public virtual DbSet<Conversation> ChatUsers { get; set; }
        
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.HasKey(e => new { e.ChatId, e.UserId });

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Conversations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}