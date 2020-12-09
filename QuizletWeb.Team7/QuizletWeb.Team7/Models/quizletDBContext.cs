using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuizletWeb.Team7.Models
{
    public partial class quizletDBContext : DbContext
    {
        public quizletDBContext()
        {
        }

        public quizletDBContext(DbContextOptions<quizletDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classcard> Classcard { get; set; }
        public virtual DbSet<Flashcard> Flashcard { get; set; }
        public virtual DbSet<Hangtonkho> Hangtonkho { get; set; }
        public virtual DbSet<Memberinfo> Memberinfo { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-IEPMHF9;Initial Catalog=quizletDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classcard>(entity =>
            {
                entity.HasKey(e => e.Classid)
                    .HasName("PK__classcar__757438067E75E4B1");

                entity.Property(e => e.Classid).IsUnicode(false);
            });

            modelBuilder.Entity<Flashcard>(entity =>
            {
                entity.Property(e => e.Flashcardid).IsUnicode(false);

                entity.Property(e => e.Classid).IsUnicode(false);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Flashcard)
                    .HasForeignKey(d => d.Classid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_idclass");
            });

            modelBuilder.Entity<Hangtonkho>(entity =>
            {
                entity.HasKey(e => e.IdHangtonkho)
                    .HasName("PK__hangtonk__7939382C4DB9C72E");

                entity.Property(e => e.IdHangtonkho).ValueGeneratedNever();

                entity.HasOne(d => d.IdSanphamNavigation)
                    .WithMany(p => p.Hangtonkho)
                    .HasForeignKey(d => d.IdSanpham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_htk_id_sanpham");
            });

            modelBuilder.Entity<Memberinfo>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__memberin__CBA1B257F8194EDD");

                entity.Property(e => e.Userid).ValueGeneratedNever();
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.IdSanpham)
                    .HasName("PK__sanpham__5D76C1A2A4CD97CB");

                entity.Property(e => e.IdSanpham).ValueGeneratedNever();

                entity.Property(e => e.PhanLoai).IsUnicode(false);

                entity.Property(e => e.TenSanpham).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
