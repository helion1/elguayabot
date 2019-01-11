using ElGuayaBot.Persistence.Contracts.Context;
using ElGuayaBot.Persistence.Model;
using Microsoft.EntityFrameworkCore;

namespace ElGuayaBot.Persistence.Implementation.Context
{
    public partial class ElGuayaBotDbContext : DbContext, IElGuayaBotDbContext
    {
        protected ElGuayaBotDbContext()
        {
        }

        public ElGuayaBotDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Chat> Groups { get; set; }
        
        public virtual DbSet<ChatUser> GroupUsers { get; set; }
        
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

                entity.Property(e => e.FirstInteractionDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChatUser>(entity =>
            {
                entity.HasKey(e => new { GroupId = e.ChatId, e.UserId });

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.ChatUsers)
                    .HasForeignKey(d => d.ChatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupUsers_Groups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupUsers_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstInteractionDate).HasColumnType("datetime");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}