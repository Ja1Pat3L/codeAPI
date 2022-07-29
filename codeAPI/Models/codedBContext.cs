using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace codeLibrary.Models
{
    public partial class codedBContext : DbContext
    {
        public codedBContext()
        {
        }

        public codedBContext(DbContextOptions<codedBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientTutorial> ClientTutorials { get; set; }
        public virtual DbSet<Tutorial> Tutorials { get; set; }
        public virtual DbSet<TutorialComment> TutorialComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=database-1.cjkozwz89t9u.us-east-1.rds.amazonaws.com,1433; database=codedB; User ID=admin; Password=admin123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.ClientAddress)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("client_address");

                entity.Property(e => e.ClientEmail)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("client_email");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("client_name");

                entity.Property(e => e.ClientPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("client_password");

                entity.Property(e => e.ClientPhone)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("client_phone");

                entity.Property(e => e.ClientPostalzip)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("client_postalzip");

                entity.Property(e => e.TutorialId).HasColumnName("tutorial_id");

                entity.HasOne(d => d.Tutorial)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.TutorialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tutorial_tutorial_id");
            });

            modelBuilder.Entity<ClientTutorial>(entity =>
            {
                entity.ToTable("client_tutorial");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.TutorialId).HasColumnName("tutorial_id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientTutorials)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_client_client_id");
            });

            modelBuilder.Entity<Tutorial>(entity =>
            {
                entity.ToTable("tutorial");

                entity.Property(e => e.TutorialId).HasColumnName("tutorial_id");

                entity.Property(e => e.TutorialDescription)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("tutorial_description");

                entity.Property(e => e.TutorialHours).HasColumnName("tutorial_hours");

                entity.Property(e => e.TutorialLanguagePreference)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tutorial_language_preference");

                entity.Property(e => e.TutorialName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tutorial_name");
            });

            modelBuilder.Entity<TutorialComment>(entity =>
            {
                entity.ToTable("tutorial_comments");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.TutorialComment1)
                    .HasMaxLength(1500)
                    .HasColumnName("tutorial_comment");

                entity.Property(e => e.TutorialCommentTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("tutorial_comment_timestamp");

                entity.Property(e => e.TutorialId).HasColumnName("tutorial_id");

                entity.HasOne(d => d.Tutorial)
                    .WithMany(p => p.TutorialComments)
                    .HasForeignKey(d => d.TutorialId)
                    .HasConstraintName("FK_tutorial_comments_tutorial_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
