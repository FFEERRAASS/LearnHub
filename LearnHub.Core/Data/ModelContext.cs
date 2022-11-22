using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LearnHub.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Studentcousre> Studentcousres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=JOR17_User117;PASSWORD=Test321;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("JOR17_USER117")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORYNAME");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Categoryid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORYID");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("CATEGORYID_FK");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.HasIndex(e => e.Username, "SYS_C00307429")
                    .IsUnique();

                entity.Property(e => e.Loginid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGINID");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Username)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("ROLEID_FK");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Studentid)
                    .HasConstraintName("STUDENTID_FK");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                entity.Property(e => e.Studentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STUDENTID");

                entity.Property(e => e.Birthdate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTHDATE");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");
            });

            modelBuilder.Entity<Studentcousre>(entity =>
            {
                entity.HasKey(e => e.Stdcid)
                    .HasName("SYS_C00307435");

                entity.ToTable("STUDENTCOUSRE");

                entity.Property(e => e.Stdcid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STDCID");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Dateofregister)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFREGISTER");

                entity.Property(e => e.Markofstd)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARKOFSTD");

                entity.Property(e => e.Stdid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STDID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Studentcousres)
                    .HasForeignKey(d => d.Courseid)
                    .HasConstraintName("COURSE1ID_FK");

                entity.HasOne(d => d.Std)
                    .WithMany(p => p.Studentcousres)
                    .HasForeignKey(d => d.Stdid)
                    .HasConstraintName("STUDENT1ID_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
