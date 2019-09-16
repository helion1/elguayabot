using ElGuayabot.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ElGuayabot.Persistence.Implementation.Context
{
    public partial class ElGuayaBotDbContext : DbContext
    {
        protected ElGuayaBotDbContext()
        {
        }

        public ElGuayaBotDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; }
        
        public virtual DbSet<ChatUser> ChatUsers { get; set; }
        
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

                entity.Property(e => e.FirstSeen).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChatUser>(entity =>
            {
                entity.HasKey(e => new { GroupId = e.ChatId, e.UserId });

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Chats)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstSeen).HasColumnType("datetime");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}