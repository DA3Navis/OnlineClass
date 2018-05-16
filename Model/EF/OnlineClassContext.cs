namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OnlineClassContext : DbContext
    {
        public OnlineClassContext()
            : base("OnlineClass")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuType> MenuTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Course>()
                .Property(e => e.PromotonPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Lessons)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CourseCategory>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<CourseCategory>()
                .HasMany(e => e.Courses)
                .WithRequired(e => e.CourseCategory)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lesson>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Lesson>()
                .Property(e => e.MetaTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Lesson>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Lesson>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Lesson>()
                .Property(e => e.LinkURL)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Slide>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Enrollments)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
